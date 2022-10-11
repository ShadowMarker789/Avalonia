using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Metadata;

namespace Avalonia.Input
{
    /// <summary>
    /// Represents a service that queries and talks to game devices. <br/> 
    /// Keyboards, mice, touchpads, or touchscreens are not considered to be game devices. 
    /// </summary>
    [NotClientImplementable]
    public interface IGameDeviceProvider
    {
        /// <summary>
        /// The name of the service that provides access to controller inputs. <br/>
        /// E.g.: XInput, GameInput, Windows.Gaming.Input, DirectInput, libudev, etc. 
        /// </summary>
        public string ProviderName { get; }

        /// <summary>
        /// Stop polling or otherwise communicating with the game devices. <br/>
        /// This service is started by default. 
        /// </summary>
        public void Stop();
        /// <summary>
        /// Start polling or otherwise communicating with the game devices. 
        /// This service is started by default. 
        /// </summary>
        public void Start();
        /// <summary>
        /// Returns true if the service is running, false otherwise. 
        /// </summary>
        public bool IsRunning { get; }

        // dev-note 
        // theoretically you could want to enable/disable ui-nav through the gamepad
        // e.g.: a in-ui control that uses the gamepad to move things around
        // you may not want to be navigating the ui simultaneously 

        /// <summary>
        /// Enables User Interface navigation through the gamepad if it was disabled earlier
        /// </summary>
        public void EnableUiNavigation();
        /// <summary>
        /// Disables User Interface navigation through the gamepad if it was enabled 
        /// </summary>
        public void DisableUiNavigation();
        /// <summary>
        /// Returns true if User Interface navigation through the gamepad is enabled, false otherwise, defaults to true. 
        /// </summary>
        public bool IsUiNavigationRunning { get; }

        /// <summary>
        /// Returns the number of devices the provider is aware of or watching. <br/>
        /// This integer is suitable for use in a for-loop to enumerate and query attached devices. 
        /// </summary>
        public int ConnectedDeviceCount { get; }
        /// <summary>
        /// Returns true if the device with index <paramref name="deviceIndex"/> is connected, false otherwise. 
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query</param>
        /// <returns>true if the device is connected, false otherwise. </returns>
        public bool IsDeviceConnected(int deviceIndex);
        /// <summary>
        /// Gets the <see cref="GameDeviceType"/> of the device with index <paramref name="deviceIndex"/><br/>
        /// Will return <see cref="GameDeviceType.GameDeviceUnknown"/> for devices not connected. 
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query</param>
        /// <returns>The device type the provider has classified it with. </returns>
        public GameDeviceType GetDeviceType(int deviceIndex);
        /// <summary>
        /// Returns the number of axes (Axes is the plural of Axis) the specified device has. <br/>
        /// The return value of this method is suitable for use in a for-loop to enumerate and query axis states. 
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query</param>
        /// <returns>The number of axes the device reports, returns zero for devices not connected. </returns>
        public int GetAxisCount(int deviceIndex);
        /// <summary>
        /// Returns the axis value that matches the specified device and axis. <br/> 
        /// 0.0d is the neutral-value / neutral-state for analog axes. <br/>
        /// Some axes will report values between -1.0d and 1.0d, others will only report values between 0.0d and 1.0d. <br/>
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query. </param>
        /// <param name="axisIndex">The 0-based axis index to query. </param>
        /// <returns>The axis value, or 0.0d if in neutral or disconnected. </returns>
        public double GetAxisValue(int deviceIndex, int axisIndex);
        /// <summary>
        /// Returns the number of buttons that the specified device has. A button is either pressed or released. <br/>
        /// Released is defined as the neutral state. <br/>
        /// This method's return value is suitable for use in a for-loop to query the set of buttons a device has. <br/>
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query. </param>
        /// <returns>The number of buttons the device reports it has. Returns zero for devices not connected. </returns>
        public int GetButtonCount(int deviceIndex);
        /// <summary>
        /// Returns true if the device's button is pressed, false otherwise. If the device is not connected will also return false. 
        /// </summary>
        /// <param name="deviceIndex">The 0-based device index to query. </param>
        /// <param name="buttonIndex">The 0-based button index to query. </param>
        /// <returns>True if the device's button is pressed, false otherwise. If the device is not connected will also return false. </returns>
        public bool IsButtonPressed(int deviceIndex, int buttonIndex);
    }
}
