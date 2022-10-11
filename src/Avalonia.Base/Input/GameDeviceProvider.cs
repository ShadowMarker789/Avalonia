using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Metadata;

namespace Avalonia.Input
{
    /// <summary>
    /// Represents a service that queries and talks to game devices. <br/> 
    /// Neither a keyboard, mouse, touchpads, or touchscreens are considered game devices for this provider. 
    /// </summary>

    public abstract class GameDeviceProvider : IGameDeviceProvider
    {
        protected static GameDeviceProvider? _currentProvider;

        /// <summary>
        /// Query for a reference to the current game device provider. <br/>
        /// There can be only up to one game device provider. May return null if there's no supported 
        /// provider for the current platform. 
        /// </summary>
        /// <returns>A reference to a <see cref="GameDeviceProvider"/> if there is one registered, else null. </returns>
        public static GameDeviceProvider? GetCurrentProvider()
        => _currentProvider;

        // dev-note: if you're wondering why these values specifically, I saw them in other gaming libs and thought 
        // that they were sensibly big-enough to cover 99+% of gaming devices and also being nice powers-of-two 
        protected const int MAX_DEVICE_COUNT = 8;
        protected const int MAX_BUTTON_COUNT = 32;
        protected const int MAX_AXIS_COUNT = 8;

        // this is more efficient than an array, probably. 
        protected FixedBuffer8<InputState> _inputStates = new FixedBuffer8<InputState>();

        /// <inheritdoc/>
        public abstract string ProviderName { get; }
        public abstract bool IsRunning { get; }
        public abstract bool IsUiNavigationRunning { get; }
        public abstract int ConnectedDeviceCount { get; }

        public abstract void DisableUiNavigation();
        public abstract void EnableUiNavigation();
        public int GetAxisCount(int deviceIndex)
        {
            // dev-note: The uint cast will handle negative-numbers for us efficiently
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }
            // dev-note: fast fixed buffer access 
            return Unsafe.Add(ref _inputStates.Item0, deviceIndex).axisCount;
        }

        public unsafe double GetAxisValue(int deviceIndex, int axisIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }
            if ((uint)axisIndex >= MAX_AXIS_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(axisIndex));
            }
            return Unsafe.Add(ref _inputStates.Item0, deviceIndex).axes[axisIndex];
        }

        public int GetButtonCount(int deviceIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }
            return Unsafe.Add(ref _inputStates.Item0, deviceIndex).buttonCount;
        }

        public GameDeviceType GetDeviceType(int deviceIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }

            return Unsafe.Add(ref _inputStates.Item0, deviceIndex).deviceType;
        }

        public bool IsButtonPressed(int deviceIndex, int buttonIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }
            if ((uint)buttonIndex >= MAX_BUTTON_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(buttonIndex));
            }

            return (Unsafe.Add(ref _inputStates.Item0, deviceIndex).buttons & (1 << buttonIndex)) != 0;
        }

        public bool IsDeviceConnected(int deviceIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }

            return Unsafe.Add(ref _inputStates.Item0, deviceIndex).isConnected;
        }

        protected InputState GetInputState(int deviceIndex)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }

            return Unsafe.Add(ref _inputStates.Item0, deviceIndex);
        }

        protected void SetInputState(int deviceIndex, InputState state)
        {
            if ((uint)deviceIndex >= MAX_DEVICE_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceIndex));
            }
            Unsafe.Add(ref _inputStates.Item0, deviceIndex) = state;
        }

        public abstract void Start();
        public abstract void Stop();

        // each device has an input-state 
        protected unsafe struct InputState
        {
            // 32 bytes for the axes, MAX_AXIS_COUNT = 8
            public fixed double axes[MAX_AXIS_COUNT];
            // bitmask for each button, another 4 bytes
            public uint buttons;
            // another 4 bytes for axisCount
            public int axisCount;
            // another 4 bytes for buttonCount
            public int buttonCount;
            // another 4 bytes for the device type
            public GameDeviceType deviceType;
            // another byte for this boolean
            public bool isConnected;

        }

        // faster than an array, possibly. 
        [StructLayout(LayoutKind.Sequential)]
        protected struct FixedBuffer8<T>
        {
            public T Item0;
            public T Item1;
            public T Item2;
            public T Item3;
            public T Item4;
            public T Item5;
            public T Item6;
            public T Item7;
        }
    }
}

