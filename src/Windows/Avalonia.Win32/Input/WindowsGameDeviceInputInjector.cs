using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Input;

namespace Avalonia.Win32.Input
{
    public static class WindowsGameDeviceInputInjector
    {
        // dev-note, this lets us change the way input is injected 
        // in case later we get proper directional navigation 

        public static void InjectUp()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Up, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Up, RawInputModifiers.None));
                }
            });
        }

        public static void InjectDown()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Down, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Down, RawInputModifiers.None));
                }
            });
        }

        public static void InjectLeft()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Left, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Left, RawInputModifiers.None));
                }
            });
        }

        public static void InjectRight()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Right, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Right, RawInputModifiers.None));
                }
            });
        }

        public static void InjectTab()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Tab, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Tab, RawInputModifiers.None));
                }
            });
        }

        public static void InjectShiftTab()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.Tab, RawInputModifiers.Shift));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.Tab, RawInputModifiers.Shift));
                }
            });
        }

        public static void InjectPageUp()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.PageUp, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.PageUp, RawInputModifiers.None));
                }
            });
        }

        public static void InjectPageDown()
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                if (FocusManager.Instance?.Current?.VisualRoot is not null &&
                FocusManager.Instance.Current.VisualRoot is IInputRoot iiroot)
                {
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyDown, Key.PageDown, RawInputModifiers.None));
                    WindowsKeyboardDevice.Instance.
                    ProcessRawEvent(new Avalonia.Input.Raw.RawKeyEventArgs(
                        WindowsKeyboardDevice.Instance, 0, iiroot, Avalonia.Input.Raw.RawKeyEventType.KeyUp, Key.PageDown, RawInputModifiers.None));
                }
            });
        }
    }
}
