using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Cube_Appplication
{
    public interface IMySampleViewCube : IView, IMin
    {
        IMySampleViewModelCube Model { get; set; }
    }
}
