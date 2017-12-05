using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;

namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample
{
	/// <summary>
	/// Interface matching the MySampleView view
	/// </summary>
	public interface IMySampleView : IView,IMin
	{
		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		IMySampleViewModel Model { get; set; }
	}
}
