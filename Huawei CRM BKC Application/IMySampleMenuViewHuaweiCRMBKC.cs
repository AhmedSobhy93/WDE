using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.Huawei_CRM_BKC_Application
{
    public interface IMySampleMenuViewHuaweiCRMBKC : IMin, IView
    {
        IMyExtensionSampleViewModelHuaweiCRMBKC Model { get; set; }

    }
}
