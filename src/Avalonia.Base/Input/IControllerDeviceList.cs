using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Metadata;

namespace Avalonia.Input
{
    [NotClientImplementable]
    public interface IControllerDeviceList
    {
        
        IAvaloniaReadOnlyList<IControllerDevice> Devices { get; }
        bool ShouldUiNavigationOccur { get; set; }
    }
}
