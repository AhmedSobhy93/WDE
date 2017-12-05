using Genesyslab.Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_AZF_Nar_Application
{
    public interface IMySampleButtonViewSlideHLR : IView
    {
        IMySampleViewModelSlideHLR Model { get; set; }

    }
}
