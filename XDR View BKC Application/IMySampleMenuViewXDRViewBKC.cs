using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.XDR_View_BKC_Application
{
    public interface IMySampleMenuViewXDRViewBKC : IMin, IView
    {
        IMyExtensionSampleViewModelXDRViewBKC Model { get; set; }

    }
}
