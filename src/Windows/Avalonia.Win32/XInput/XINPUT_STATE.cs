using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal struct XINPUT_STATE
    {
        
        [NativeTypeName("DWORD")]
        public uint dwPacketNumber;

        
        public XINPUT_GAMEPAD Gamepad;
    }
}
