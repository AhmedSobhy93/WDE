using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.HLR_AZF_Nar_Application
{
    public interface IMySampleMenuViewHLR : IMin, IView
    {
        IMyExtensionSampleViewModelHLR Model { get; set; }

    }
}
