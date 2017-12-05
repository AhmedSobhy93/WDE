using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.Cube_application
{
    public interface extensionSampleViewCube : IMin, IView
    {
        /// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		MySampleViewModelCube Model { get; set; }
    }
}
