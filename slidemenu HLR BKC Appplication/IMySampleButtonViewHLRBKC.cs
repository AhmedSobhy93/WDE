using Genesyslab.Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication
{
    public interface IMySampleButtonViewHLRBKC : IView
    {
        IMySampleViewModelHLRBKC Model { get; set; }
    }
}
