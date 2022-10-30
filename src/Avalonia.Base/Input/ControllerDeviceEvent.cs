using System;
using System.Runtime.InteropServices;

namespace Avalonia.Input
{
    
    public struct ControllerDeviceEvent
    {
        
        public ControllerDeviceEventType EventType;
        public ulong Timestamp;
        // union of ControllerButtonChange and ControllerAxisChange
        public ControllerChangeInfo ChangeInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ControllerChangeInfo
    {
        [FieldOffset(0)]
        public ControllerButtonChange ButtonInfo;
        [FieldOffset(0)]
        public ControllerAxisChange AxisInfo;
    }

    public struct ControllerButtonChange
    {
        public ControllerDeviceButton ChangedButton;
        public double OldState;
        public double NewState;
    }

    public struct ControllerAxisChange
    {
        public ControllerDeviceAxis ChangedAxis;
        public double OldState;
        public double NewState;
    }

    public enum ControllerDeviceEventType
    {
        Button,
        Axis
    }
}
