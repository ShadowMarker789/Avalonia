using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal struct XINPUT_CAPABILITIES
    {
        public byte Type;

        public byte SubType;

        [NativeTypeName("WORD")]
        public ushort Flags;
        
        public XINPUT_GAMEPAD Gamepad;

        public XINPUT_VIBRATION Vibration;
    }
}
