using Genesyslab.Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Cube_Appplication
{
    public  interface IMySampleButtonViewCube : IView
    {
        IMySampleViewModelCube Model { get; set; }

    }
}
