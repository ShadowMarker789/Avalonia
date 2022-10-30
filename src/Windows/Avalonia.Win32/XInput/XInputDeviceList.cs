using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Input;
using Avalonia.Logging;
using Avalonia.Rendering;
using static Avalonia.Win32.XInput.XInput1v4UnmanagedMethods;

namespace Avalonia.Win32.XInput
{
#nullable enable
    internal class XInputDeviceList : IControllerDeviceList
    {
        private AvaloniaList<IControllerDevice> _devices;
        public IAvaloniaReadOnlyList<IControllerDevice> Devices
            => _devices;

        public bool ShouldUiNavigationOccur { get; set; }


        private Thread? _xInputThread = null;
        private IRenderTimer? _renderTimer = null;
        private bool _renderTimerSubscribed = false;
        private AutoResetEvent _tickEvent = new AutoResetEvent(false);
        private static object _syncLock = new object();

        public XInputDeviceList()
        {
            _devices = new AvaloniaList<IControllerDevice>();

        }

        private unsafe void RunEntryPoint()
        {
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

            }

#if DEBUG
            if (_renderTimer is null)
            {
                System.Diagnostics.Trace.Fail("Did not get a render timer", "I do not know why this has happened");
                return;
            }
#else
            if (_renderTimer is null)
            {
                Logger.TryGet(LogEventLevel.Error, "XInput")
                        ?.Log(this, "Did not obtain a render timer to tick against, XInput thread terminating. ");
                return;
            }
#endif
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

                // TODO: Figure out an exit condition 
                while (true)
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
                            // TODO: Mark device not connected 
                            continue;
                        }
                        if (retval != 0)
                        {
                            Logger.TryGet(LogEventLevel.Warning, "XInput")
                                ?.Log(this, $"Unexpected return-value [0x{retval:x}] obtained from {nameof(XInputGetState)}");
                            // TODO: Mark device not connected 
                            continue;
                        }

                        // we have a valid state now, how about we use it? 


                    }

                }
            }
            catch (Exception ex)
            {
                Logger.TryGet(LogEventLevel.Error, "XInput")
                    ?.Log(this, $"Unexpected exception in {nameof(RunEntryPoint)}: {ex.GetType()}::{ex.Message}, {ex}");
            }
            finally
            {
                _renderTimer.Tick -= tickHandler;
            }
        }

        internal void Run()
        {
            lock(_syncLock)
            {
                if (_xInputThread is not null && !_xInputThread.IsAlive)
                {
                    Logger.TryGet(LogEventLevel.Error, "XInput")
                        ?.Log(this, "We're already running why are you calling start again?");
                    return;
                }

                // it is unfortunate that XInput is a polling mechanism instead of a eventing mechanism
                // so we must poll repeatedly, and the render-tick is sufficent for this, probably. 
                _xInputThread = new Thread(RunEntryPoint);
                _xInputThread.IsBackground = true;
                _xInputThread.SetApartmentState(ApartmentState.STA);
                _xInputThread.Name = "XInput Poll Thread";
                _xInputThread.Start();
            }
        }

        internal static XInputDeviceList? TryCreateAndRegister()
        {
            // any Windows OS that's able to run Framework v 4.7 or above 
            // absolutely should have XInput v 1.4 available 
            // I do not see any reason this would fail, outside of calling it on the wrong
            // operating system type, like linux or mac or something. 

            try
            {
                var list = new XInputDeviceList();
                var locator = AvaloniaLocator.CurrentMutable;
                locator.BindToSelf(list);
                locator.Bind<IControllerDeviceList>().ToConstant(list);
                return list;
            }
            catch (Exception ex)
            {
                Logger.TryGet(LogEventLevel.Error, "XInput")
                    ?.Log(null, "Unable to initialize XInput DeviceList: {0}", ex);
            }
            return null;
        }
    }

#nullable restore
}
