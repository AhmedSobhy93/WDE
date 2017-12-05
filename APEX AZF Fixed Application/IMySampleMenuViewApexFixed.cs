using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.APEX_AZF_Fixed_Application
{
    public interface IMySampleMenuViewApexFixed : IMin, IView
    {
        IMyExtensionSampleViewModelApexFixed Model { get; set; }

    }
}
