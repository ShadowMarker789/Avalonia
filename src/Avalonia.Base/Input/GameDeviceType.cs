using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Input
{
    /// <summary>
    /// The set of possible Game Devices
    /// </summary>
    public enum GameDeviceType
    {
        /// <summary>
        /// There is zero confidence that the device is actually a game device. <br/>
        /// E.g.: It could be a keyboard or a touchpad. 
        /// </summary>
        GameDeviceUnknown,
        /// <summary>
        /// The device is likely a game device; it has axes and buttons. <br/>
        /// It either does not match any well-known formats or was from a provider unaware of these kinds of devices. 
        /// </summary>
        GameDeviceGeneric,
        /// <summary>
        /// The first generation of gamepads. Has 4 face buttons, two analog sticks that can themselves click as buttons, 
        /// a directional pad of four buttons, two middle buttons as well as 2 shoulder buttons and 2 shoulder axes. <br/>
        /// This is the standard gamepad that most are familiar with. The Xbox360, Playstation, Switch, Steam controllers
        /// match this variant as well as the set of generic controllers that are XInput compliant. 
        /// </summary>
        GameDeviceGamepad1,
        /// <summary>
        /// The second generation of gamepads. The second generation is much like <see cref="GameDeviceGamepad1"/> 
        /// but also has two additional buttons at the back of the controller. <br/>
        /// These belong to the Xbox One X and similar. All GameDeviceGamepad2 devices can be accessed alike a 
        /// <see cref="GameDeviceGamepad1"/> device. 
        /// </summary>
        GameDeviceGamepad2,
    }
}
