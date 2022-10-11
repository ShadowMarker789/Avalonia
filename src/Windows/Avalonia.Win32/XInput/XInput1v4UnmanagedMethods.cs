using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Win32.NativeInteropDecorations;

namespace Avalonia.Win32.XInput
{
    internal unsafe class XInput1v4UnmanagedMethods
    {
        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputGetState([NativeTypeName("DWORD")] uint dwUserIndex, XINPUT_STATE* pState);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputSetState([NativeTypeName("DWORD")] uint dwUserIndex, XINPUT_VIBRATION* pVibration);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputGetCapabilities([NativeTypeName("DWORD")] uint dwUserIndex, [NativeTypeName("DWORD")] uint dwFlags, XINPUT_CAPABILITIES* pCapabilities);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        // dev-note: int here maps onto BOOL MSVC datatype, which is an int 
        public static extern void XInputEnable(int enable);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputGetAudioDeviceIds([NativeTypeName("DWORD")] uint dwUserIndex, [NativeTypeName("LPWSTR")] ushort* pRenderDeviceId, uint* pRenderCount, [NativeTypeName("LPWSTR")] ushort* pCaptureDeviceId, uint* pCaptureCount);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputGetBatteryInformation([NativeTypeName("DWORD")] uint dwUserIndex, byte devType, XINPUT_BATTERY_INFORMATION* pBatteryInformation);

        
        [DllImport("xinput1_4", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        public static extern uint XInputGetKeystroke([NativeTypeName("DWORD")] uint dwUserIndex, [NativeTypeName("DWORD")] uint dwReserved, [NativeTypeName("PXINPUT_KEYSTROKE")] XINPUT_KEYSTROKE* pKeystroke);

        [NativeTypeName("#define XUSER_MAX_COUNT 4")]
        public const int XUSER_MAX_COUNT = 4;

        [NativeTypeName("#define XUSER_INDEX_ANY 0x000000FF")]
        public const int XUSER_INDEX_ANY = 0x000000FF;
    }
}
