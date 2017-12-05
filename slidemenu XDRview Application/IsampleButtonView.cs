using Genesyslab.Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Huawei_CRM_AZF_Nar
{
    public interface IsampleButtonView : IView
    {
        IsampleViewModel Model { get; set; }

    }
}
