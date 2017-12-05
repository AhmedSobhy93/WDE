using Genesyslab.Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.views
{
    public interface IITabView : IView
    {
        IITabViewModel Model { get; set; }

    }
}
