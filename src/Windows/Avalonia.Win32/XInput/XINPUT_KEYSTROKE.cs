using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal struct XINPUT_KEYSTROKE
    {
        [NativeTypeName("WORD")]
        public ushort VirtualKey;

        [NativeTypeName("WCHAR")]
        public ushort Unicode;

        [NativeTypeName("WORD")]
        public ushort Flags;

        public byte UserIndex;

        public byte HidCode;
    }
}
