using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.APEX_BKC_Application
{
    public interface IMySampleMenuViewApexBKC : IMin, IView
    {
        IMyExtensionSampleViewModelApexBKC Model { get; set; }

    }
}
