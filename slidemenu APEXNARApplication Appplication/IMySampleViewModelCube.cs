using Genesyslab.Desktop.Modules.Core.Model.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Cube_Appplication
{
    public interface IMySampleViewModelCube
    {
        /// <summary>
		/// Gets or sets the header to set in the parent view.
		/// </summary>
		/// <value>The header.</value>
		string Header { get; set; }

        /// <summary>
        /// Gets or sets the counter.
        /// </summary>
        /// <value>The counter.</value>
        TimeSpan Counter { get; set; }

        /// <summary>
        /// Gets or sets the case.
        /// </summary>
        /// <value>The case.</value>
        ICase Case { get; set; }

        /// <summary>
        /// Reset the counter.
        /// </summary>
        void ResetCounter();
    }
}
