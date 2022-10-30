using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Metadata;

namespace Avalonia.Input
{
    [NotClientImplementable]
    public interface IControllerDevice
    {
        IReadOnlyList<ControllerDeviceButton> AvailableButtons { get; }
        // note that the plural of axis is axes 🪓
        IReadOnlyList<ControllerDeviceAxis> AvailableAxes { get; }
        /// <summary>
        /// 0.0d is not pressed, 1.0d is pressed, some "buttons" are analog 
        /// </summary>
        IReadOnlyList<double> ButtonStates { get; }
        IReadOnlyList<double> AxisStates { get; }
        bool IsConnected { get; }
        IObservable<ControllerDeviceEvent> Events { get; }
        bool ShouldUiNavigationOccur { get; set; }

        int GetButtonIndex(ControllerDeviceButton button);
        int GetAxisIndex(ControllerDeviceAxis axis);

        // capture API 
        public bool TryCapture(IObservable<ControllerDeviceEvent> eventSink, bool runOnBackgroundThread);
        public bool ReleaseCapture(IObservable<ControllerDeviceEvent> eventSink);
    }
}
