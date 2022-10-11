using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal struct XINPUT_VIBRATION
    {
        [NativeTypeName("WORD")]
        public ushort wLeftMotorSpeed;

        [NativeTypeName("WORD")]
        public ushort wRightMotorSpeed;
    }
}
