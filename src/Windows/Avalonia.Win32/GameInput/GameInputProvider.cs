using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using Avalonia.Input;
using Avalonia.Logging;
using Avalonia.Rendering;
using Avalonia.Win32.Input;
using Microsoft.Gdk.GameInput;

namespace Avalonia.Win32.GameInput
{
#nullable enable
    // DEV-NOTE: GAMEINPUT IS NOT YET SUITABLE FOR END-USER CONSUMPTION 
    // REVIEW GAMEINPUT WHEN THEY FIX / PATCH IT IN LATER RELEASES 
    // LAST TESTED 2022-10-11 
    public class GameInputProvider : GameDeviceProvider
    {
        public override string ProviderName => "GameInput";

        private bool _isRunning = false;
        public override bool IsRunning => _isRunning;

        private bool _isUiNavigationRunning = true;
        public override bool IsUiNavigationRunning => _isUiNavigationRunning;

        private int _connectedDeviceCount = 0;
        public override int ConnectedDeviceCount => _connectedDeviceCount;

        private Thread? _gameInputThread = null;

        private static IntPtr _gameInputPointer = IntPtr.Zero;

        private IRenderTimer? _renderTimer = null;

        private bool _renderTimerSubscribed = false;

        private AutoResetEvent _tickEvent = new AutoResetEvent(false);

        private GameInputKind _gameInputKindFilter =
                    GameInputKind.GameInputKindUiNavigation |
                    GameInputKind.GameInputKindGamepad |
                    GameInputKind.GameInputKindController;

        private static GameInputProvider? _instance;

        private static object _syncLock = new object();

        private GameInputUiNavigationState navState = default;
        private GameInputUiNavigationState prevNavState = default;

        public override void DisableUiNavigation()
        {
            _isUiNavigationRunning = false;
        }

        public override void EnableUiNavigation()
        {
            _isUiNavigationRunning = true;
        }

        public override void Start()
        {
            lock (_syncLock)
            {
                if (_gameInputThread is not null && !_gameInputThread.IsAlive)
                {
                    Logger.TryGet(LogEventLevel.Error, "GameInput")
                        ?.Log(null, "We already have a GameInput thread why are you calling Start again?");
                    return;
                }

                _gameInputThread = new Thread(RunEntryPoint);
                _gameInputThread.IsBackground = true;
                _gameInputThread.SetApartmentState(ApartmentState.STA);
                _gameInputThread.Name = $"GameInput Poll Thread";
                _gameInputThread.Start();
            }
        }

        public override void Stop()
        {
            // TODO: Implement 
            _isRunning = false;
        }

        private unsafe void RunEntryPoint()
        {
            _isRunning = true;

            if (_renderTimer is null)
            {
                _renderTimer = AvaloniaLocator.Current.GetService<IRenderTimer>();
                if (_renderTimer is null)
                {
                    // well fudge, we'll keep trying until we get it. 
                    SpinWait.SpinUntil(() =>
                    {
                        _renderTimer = AvaloniaLocator.Current.GetService<IRenderTimer>();
                        return _renderTimer is not null;
                    });
                }

                System.Diagnostics.Trace.Assert(_renderTimer is not null, "Did not get a render timer", "I do not know why this has happened");
            }

            if (_renderTimer is null)
            {
                // just in case the render-timer isn't there? 
                // I don't want to be spinning for too long or too frequently polling the gamepad 
                _isRunning = false;

                return;
            }

            var keyboard = WindowsKeyboardDevice.Instance;

            var tickHandler = (TimeSpan ts) =>
            {
                _tickEvent.Set();
            };

            if (!_renderTimerSubscribed)
            {
                _renderTimerSubscribed = true;
                _renderTimer.Tick += tickHandler;
            }

            System.Diagnostics.Trace.Assert(_gameInputPointer != IntPtr.Zero, "GameInput pointer is null", "I do not know why this has happened");

            IGameInput* input = (IGameInput*)_gameInputPointer;

            ulong callbackToken = default;

            // // dev-note: if you call this method on current windows system 
            // // you break gameinput simultaneously for all processes for all users
            // // until you restart the system 
            //input->RegisterDeviceCallback(
            //    null,
            //    _gameInputKindFilter,
            //    GameInputDeviceStatus.GameInputDeviceConnected,
            //    GameInputEnumerationKind.GameInputAsyncEnumeration,
            //    null,

            //    (delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, GameInputDeviceStatus, GameInputDeviceStatus, void>)Marshal.GetFunctionPointerForDelegate(OnRegisterDeviceCallback),

            //    &callbackToken);
            
            int hresult = 0;
            while (_isRunning)
            {
                _tickEvent.WaitOne();
                //System.Diagnostics.Trace.WriteLine($"\tTICK!!");

                lock (_syncLock)
                {
                    // do tick here 
                    IGameInputReading* previousReading = null;
                    hresult = input->GetCurrentReading(_gameInputKindFilter, null, &previousReading);
                    if (hresult == 0)
                    {
                        HandleReading(previousReading);
                        if (previousReading is not null)
                        {
                            previousReading->Release();
                            previousReading = null;
                        }
                    }
                }
            }

            // same as above, if we register the callback everything breaks, so don't until GameInput is patched 
            // input->UnregisterCallback(callbackToken, 5000);
            _renderTimer.Tick -= tickHandler;
            _renderTimerSubscribed = false;
        }

        private unsafe void HandleReading(IGameInputReading* reading)
        {
            GameInputUiNavigationState pState = default;
            if (_isUiNavigationRunning && reading->GetUiNavigationState(&pState))
            {
                navState = pState;
                IGameInputDevice* device = null;
                reading->GetDevice(&device);

                if (navState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationUp))
                {
                    if (!prevNavState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationUp))
                    {
                        System.Diagnostics.Trace.WriteLine($"[{NowString()}] [0x{(IntPtr)device:x}] UP");
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
                }

                if (navState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationDown))
                {
                    if (!prevNavState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationDown))
                    {
                        System.Diagnostics.Trace.WriteLine($"[{NowString()}] [0x{(IntPtr)device:x}] DOWN");
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
                }

                if (navState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationLeft))
                {
                    if (!prevNavState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationLeft))
                    {
                        System.Diagnostics.Trace.WriteLine($"[{NowString()}] [0x{(IntPtr)device:x}] LEFT");
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
                }

                if (navState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationRight))
                {
                    if (!prevNavState.buttons.HasFlag(GameInputUiNavigationButtons.GameInputUiNavigationRight))
                    {
                        System.Diagnostics.Trace.WriteLine($"[{NowString()}] [0x{(IntPtr)device:x}] RIGHT");
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
                }

                prevNavState = navState;
                device->Release();
            }
        }

        public GameInputProvider()
        {

        }

        public static unsafe bool CheckSystemSatisfaction()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {


                IntPtr module;
                // Okay but do we have GameInput? 

                module = LoadLibrary("GameInput.dll");

                if (module == IntPtr.Zero)
                {
                    // no GameInput.dll 
                    
                    return false;
                }

                IntPtr GameInputCreate = IntPtr.Zero;

                GameInputCreate = GetProcAddress(module, "GameInputCreate");

                if (GameInputCreate == IntPtr.Zero)
                {
                    // somehow GameInput.dll does not have entrypoint GameInputCreate 
                    return false;
                }

                var gameInputCreate = (delegate* unmanaged[Stdcall]<void*, IntPtr>)GameInputCreate;

                IntPtr testPointer;
                gameInputCreate(&testPointer);

                if (testPointer == IntPtr.Zero)
                {
                    // somehow calling GameInputCreate did not yield a valid pointer, which makes me sad. 
                    return false;
                }

                _gameInputPointer = testPointer;

                return true;
            }
            else
            {
                // why would you even try this 
                return false;
            }
        }

        public static GameInputProvider? TryCreateAndRegister()
        {
            try
            {
                // if system not happy with gameinput, then do not 
                if (CheckSystemSatisfaction() == false)
                    return null;
                GameInputProvider gip = new GameInputProvider();
                _currentProvider = _instance = gip;
                // okay it worked! 
                gip.Start();
                var loca = AvaloniaLocator.CurrentMutable;
                loca.BindToSelf(gip);
                loca.Bind<IGameDeviceProvider>().ToConstant(gip);

            }
            catch (Exception ex)
            {
                Logger.TryGet(LogEventLevel.Error, "GameInput")
                    ?.Log(null, "Unable to initialize GameInput GameDeviceProvider: {0}", ex);
            }
            return null;
        }

        public static unsafe void OnRegisterDeviceCallback(ulong ul, void* pv, IGameInputDevice* device, ulong ul2, GameInputDeviceStatus status1, GameInputDeviceStatus status2)
        {
            System.Diagnostics.Trace.WriteLine($"{nameof(OnRegisterDeviceCallback)}: {device->GetDeviceInfo()->productId}, status = 0x{status1:x}");

            if (status1.HasFlag(GameInputDeviceStatus.GameInputDeviceConnected) && status1.HasFlag(GameInputDeviceStatus.GameInputDeviceInputEnabled))
            {
                System.Diagnostics.Trace.WriteLine($"[{NowString()}] Intent to add device 0x{(IntPtr)device:x} to device list");
            }
            else
            {
                System.Diagnostics.Trace.WriteLine($"{NowString()} Intent to remove device 0x{(IntPtr)device:x} from device list");
            }
        }

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32", EntryPoint = "LoadLibraryW", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpszLib);

        private static string NowString()
        {
            return DateTime.Now.ToString("yyyy-MM-DDTHH:mm:ss.FFF");
        }
    }
#nullable restore
}
