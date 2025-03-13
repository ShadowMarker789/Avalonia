using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Avalonia.Input;
using Avalonia.Win32.Interop;

namespace Avalonia.Win32.Input
{
    public class WindowsGamepadManager : GamepadManager
    {
        private const int OPEN_EXISTING = 3;
        private const int FILE_SHARE_READ = 0x00000001;
        private const int FILE_SHARE_WRITE = 0x00000002;
        private const uint GENERIC_READ = (0x80000000);
        private const int GENERIC_WRITE = (0x40000000);
        private const ushort HID_USAGE_PAGE_GENERIC = ((ushort)(0x01));
        private const ushort HID_USAGE_GENERIC_GAMEPAD = ((ushort)(0x05));
        private const ushort HID_USAGE_GENERIC_JOYSTICK = ((ushort)(0x04));
        private const ushort HID_USAGE_GENERIC_MULTI_AXIS_CONTROLLER = ((ushort)(0x08));
        private const nint GIDC_ARRIVAL = 1;
        private const nint GIDC_REMOVAL = 2;
        private const int RID_INPUT = 0x10000003;
        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RIDEV_DEVNOTIFY = 0x00002000;
        private const int RIDI_DEVICENAME = 0x20000007;
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private SimpleWindow? _simpleWindow;
        private Thread _messagePumpThread;
        private List<InternalGamepadData> _knownDevices = new();

        public WindowsGamepadManager()
        {
            Instance = this;
            _messagePumpThread = new Thread(MessagePumpThreadStart);
            _messagePumpThread.SetApartmentState(ApartmentState.STA);
            _messagePumpThread.Name = $"{nameof(WindowsGamepadManager)}::{nameof(MessagePumpThreadStart)}";
            _messagePumpThread.IsBackground = true;
            _messagePumpThread.Start();
        }

        private unsafe void MessagePumpThreadStart()
        {
            // I noticed this occurring way too fast, so slow it down a bit to give user code some time to register their event-handlers
            Thread.Sleep(500);
            _simpleWindow = new(GamepadWndProc);

            RAWINPUTDEVICE* rids = stackalloc RAWINPUTDEVICE[4];
            Span<RAWINPUTDEVICE> spanRids = new Span<RAWINPUTDEVICE>(rids, 4);

            for (int i = 0; i < 4; i++)
            {
                spanRids[i].usUsagePage = HID_USAGE_PAGE_GENERIC;
                // if you add these two options together, then you get input even out of focus 
                spanRids[i].dwFlags = RIDEV_INPUTSINK | RIDEV_DEVNOTIFY;
                spanRids[i].hwndTarget = _simpleWindow.Handle;
            }

            spanRids[0].usUsage = HID_USAGE_GENERIC_GAMEPAD;
            spanRids[1].usUsage = HID_USAGE_GENERIC_JOYSTICK;
            spanRids[2].usUsage = HID_USAGE_GENERIC_MULTI_AXIS_CONTROLLER;

            var registerReturn = UnmanagedMethods.RegisterRawInputDevices(rids, 3, (uint)sizeof(RAWINPUTDEVICE));
            if (registerReturn == 0x0)
            {
                // TODO: Log failure to register raw input devices 
            }

            // for XInput, which says to poll at 8ms or 125 Hz
            // null for proc so it posts the message to our WndProc for convenience
            UnmanagedMethods.SetTimer(_simpleWindow.Handle, IntPtr.Zero, 8, null);

            while (true)
            {
                if (UnmanagedMethods.GetMessage(out var msg, _simpleWindow.Handle, 0, 0) != 0x0)
                {
                    UnmanagedMethods.TranslateMessage(ref msg);
                    UnmanagedMethods.DispatchMessage(ref msg);
                }
            }
        }

        private unsafe IntPtr GamepadWndProc(IntPtr hwnd, uint message, IntPtr wParam, IntPtr lparam)
        {
            UnmanagedMethods.WindowsMessage msg = (UnmanagedMethods.WindowsMessage)message;
            switch (msg)
            {
                case UnmanagedMethods.WindowsMessage.WM_INPUT:
                    {
                        RAWINPUT rwInput = default;
                        uint rwInputSize = (uint)sizeof(RAWINPUT);
                        // Turns out this isn't an HRESULT (haha)
                        // See: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdata
                        var result = UnmanagedMethods.GetRawInputData(lparam, RID_INPUT, (IntPtr)(&rwInput), &rwInputSize, (uint)(sizeof(RAWINPUTHEADER)));
                        if (result == unchecked((uint)-1))
                        {
                            // an error has occurred 
                            // TODO: Log error
                        }
                        else
                        {
                            DispatchRawInputStateChange(rwInput);
                        }
                    }
                    break;
                case UnmanagedMethods.WindowsMessage.WM_INPUT_DEVICE_CHANGE:
                    {
                        // info: the LPARAM is the HANDLE to the raw input device
                        if (wParam == GIDC_ARRIVAL)
                        {
                            // Process device being added / initialized
                            RawInputDeviceAdded(lparam);
                        }
                        else if (wParam == GIDC_REMOVAL)
                        {
                            // Process device being removed / disconnected 
                            RawInputDeviceRemoved(lparam);
                        }
                    }
                    break;
                case UnmanagedMethods.WindowsMessage.WM_TIMER:
                    {
                        DoXInput();
                    }
                    break;
            }

            return UnmanagedMethods.DefWindowProc(hwnd, message, wParam, lparam);
        }

        private unsafe void RawInputDeviceAdded(IntPtr deviceHandle)
        {
            Console.WriteLine(deviceHandle);
            Trace.WriteLine(deviceHandle);

            // get the device ID 
            uint nameSize = 0;
            UnmanagedMethods.GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, null, &nameSize);
            // this stack allocation is fine since the current thread is NOT the Dispatcher thread
            // AND we're very shallow in our calling stack
            char* pDeviceName = stackalloc char[(int)nameSize];
            UnmanagedMethods.GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, pDeviceName, &nameSize);
            // note that deviceName is the really long //?/HID style name 
            // See https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdeviceinfow
            // And windows guarantees that the same device will have the same device-name 
            string deviceName = new string(pDeviceName);

            InternalGamepadData? data = null;
            for (int i = 0; i < _knownDevices.Count; i++)
            {
                if (string.Equals(_knownDevices[i].Id, deviceName, StringComparison.OrdinalIgnoreCase))
                {
                    data = _knownDevices[i];
                }
            }
            if (data is null)
            {
                var handle = UnmanagedMethods.CreateFileW((ushort*)pDeviceName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, null, OPEN_EXISTING, 0x0, IntPtr.Zero);
                if (handle == IntPtr.Zero || handle == INVALID_HANDLE_VALUE)
                {
                    return;
                }

                // if you're wondering where 2046 comes from, it's half of 4092 
                // and if you're wondering where 4092 comes from 
                // https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getproductstring
                char* pwstrProductString = stackalloc char[2046];
                if (UnmanagedMethods.HidD_GetProductString(handle, pwstrProductString, 4092) == 0)
                {
                    // TODO: Log failure
                    UnmanagedMethods.CloseHandle(handle);
                    return;
                }
                string humanName = new string(pwstrProductString);
                // okay this looks weird, but apparently that's just how it's done. 🤷‍
#if NETSTANDARD2_0
                bool isXInputDevice = deviceName.IndexOf("IG_", StringComparison.OrdinalIgnoreCase) != -1;
#else
                bool isXInputDevice = deviceName.Contains("IG_", StringComparison.OrdinalIgnoreCase);
#endif

                UnmanagedMethods.CloseHandle(handle);
                data = new InternalGamepadData(_knownDevices.Count, deviceName, humanName, isXInputDevice);
                data.LastHandle = deviceHandle;
                _knownDevices.Add(data);

                Trace.WriteLine($"New Device! [{humanName}] is {(isXInputDevice ? "" : "NOT ")}an XInput device!");
            }
            else
            {
                Trace.WriteLine($"Recognized Device! [{data.HumanName}] is {(data.IsXInputDevice ? "" : "NOT ")} an XInput device!");
            }
            PushGamepadEvent(
                new GamepadEventArgs()
                {
                    Connected = data.IsConnected,
                    Device = data.Index,
                    HumanName = data.HumanName,
                    Id = data.Id,
                    Timestamp = data.Timestamp,
                    Source = this,
                    EventType = data.EventTracking
                }
            );
        }

        private void RawInputDeviceRemoved(IntPtr deviceHandle)
        {
            for (int i = 0; i < _knownDevices.Count; i++)
            {
                var data = _knownDevices[i];
                if (data.LastHandle == deviceHandle)
                {
                    PushGamepadEvent(
                        new GamepadEventArgs()
                        {
                            Connected = data.IsConnected,
                            Device = data.Index,
                            HumanName = data.HumanName,
                            Id = data.Id,
                            Timestamp = data.Timestamp,
                            Source = this,
                            EventType = data.EventTracking
                        }
                    );
                }
            }
        }

        private void DispatchRawInputStateChange(RAWINPUT rawInputEvent)
        {
            for (int i = 0; i < _knownDevices.Count; i++)
            {
                var data = _knownDevices[i];
                if (rawInputEvent.header.hDevice == data.LastHandle)
                {
                    Trace.WriteLine("State change!");
                }
            }
        }

        private void DoXInput()
        {

        }

        private class InternalGamepadData
        {
            public InternalGamepadData(int index, string id, string humanName, bool isXInputDevice)
            {
                Index = index;
                Id = id;
                HumanName = humanName;
                IsXInputDevice = isXInputDevice;
            }
            public int Index { get; set; }
            public string Id { get; set; }
            public string HumanName { get; set; }
            public bool IsXInputDevice { get; set; }
            public bool IsConnected { get; set; }
            public GamepadEventArgs.GamepadEventType EventTracking { get; set; }
            public DateTime Timestamp { get; set; }
            public IntPtr LastHandle { get; set; }
            public int XInputDeviceIndex { get; set; } = -1;
        }
    }
}
