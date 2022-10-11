using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal struct XINPUT_GAMEPAD
    {
        
        [NativeTypeName("WORD")]
        public ushort wButtons;

        public byte bLeftTrigger;

        public byte bRightTrigger;

        public short sThumbLX;

        public short sThumbLY;

        public short sThumbRX;

        public short sThumbRY;
    }
}
