using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_AZF_Nar_Application
{
    public interface IMySampleViewSlideHLR : IView, IMin
    {
        /// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		IMySampleViewModelSlideHLR Model { get; set; }
    }
}
