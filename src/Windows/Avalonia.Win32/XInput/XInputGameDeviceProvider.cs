using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Input;
using Avalonia.Logging;
using Avalonia.Rendering;
using static Avalonia.Win32.XInput.XInput1v4UnmanagedMethods;

namespace Avalonia.Win32.XInput
{
#nullable enable
    public class XInputGameDeviceProvider : GameDeviceProvider
    {
        public override string ProviderName => nameof(XInputGameDeviceProvider);

        private bool _isRunning = false;
        public override bool IsRunning => _isRunning;

        private bool _isUiNavigationRunning = true;
        public override bool IsUiNavigationRunning => _isUiNavigationRunning;

        private int _connectedDeviceCount = 0;
        public override int ConnectedDeviceCount => _connectedDeviceCount;

        private Thread? _xInputThread = null;
        private IRenderTimer? _renderTimer = null;
        private bool _renderTimerSubscribed = false;
        private AutoResetEvent _tickEvent = new AutoResetEvent(false);
        private static object _syncLock = new object();
        private XINPUT_GAMEPAD _previousState = default;

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
                if (_xInputThread is not null && !_xInputThread.IsAlive)
                {
                    Logger.TryGet(LogEventLevel.Error, "XInput")
                        ?.Log(this, "We're already running why are you calling start again?");
                    return;
                }

                _xInputThread = new Thread(RunEntryPoint);
                _xInputThread.IsBackground = true;
                _xInputThread.SetApartmentState(ApartmentState.STA);
                _xInputThread.Name = "XInput Poll Thread";
                _xInputThread.Start();
            }
        }

        public override void Stop()
        {
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
#if DEBUG
                System.Diagnostics.Trace.Assert(_renderTimer is not null, "Did not get a render timer", "I do not know why this has happened");
#endif
            }

            if (_renderTimer is null)
            {
                // just in case the render-timer isn't there? 
                // I don't want to be spinning for too long or too frequently polling the gamepad 
                _isRunning = false;

                return;
            }

            var tickHandler = (TimeSpan ts) =>
            {
                _tickEvent.Set();
            };

            if (!_renderTimerSubscribed)
            {
                _renderTimerSubscribed = true;
                _renderTimer.Tick += tickHandler;
            }

            try
            {

                while(_isRunning)
                {
                    _tickEvent.WaitOne();
                    
                    // why 4? XInput supports up to 4 controllers at once 
                    for (uint i = 0; i < 4; i++)
                    {
                        XINPUT_STATE state;
                        var retval = XInputGetState(i, &state);
                        if (retval == 1167u)
                        {
                            // 1167u 0x48F is ERROR_DEVICE_NOT_CONNECTED 
                            this.SetInputState((int)i, default);
                            continue;
                        }
                        if (retval != 0)
                        {
                            Logger.TryGet(LogEventLevel.Warning, "XInput")
                                ?.Log(this, $"Unexpected return-value [0x{retval:x}] obtained from {nameof(XInputGetState)}");
                            this.SetInputState((int)i, default);
                            continue;
                        }

                        // we have a valid state now, how about we use it? 

                    }

                }
            }
            catch(Exception ex)
            {
                Logger.TryGet(LogEventLevel.Error, "XInput")
                    ?.Log(this, $"Unexpected exception in {nameof(RunEntryPoint)}: {ex.GetType()}::{ex.Message}, {ex}");
            }
            finally
            {
                _renderTimer.Tick -= tickHandler;
                _isRunning = false;
            }
        }

        internal static XInputGameDeviceProvider? TryCreateAndRegister()
        {
            // any Windows OS that's able to run Framework v 4.7 or above 
            // absolutely should have XInput v 1.4 available 
            // I do not see any reason this would fail, outside of calling it on the wrong
            // operating system type, like linux or mac or something. 
            try
            {
                var retval = new XInputGameDeviceProvider();
                _currentProvider = retval;
                retval.Start();
                var loca = AvaloniaLocator.CurrentMutable;
                loca.BindToSelf(retval);
                loca.Bind<IGameDeviceProvider>().ToConstant(retval);
                return retval;
            }
            catch(Exception ex)
            {
                Logger.TryGet(LogEventLevel.Error, "XInput")
                    ?.Log(null, "Unable to initialize GameInput GameDeviceProvider: {0}", ex);
            }
            return null;
        }
    }
#nullable restore
}
