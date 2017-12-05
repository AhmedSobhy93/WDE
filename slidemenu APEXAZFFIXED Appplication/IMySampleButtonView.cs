using Genesyslab.Desktop.Infrastructure;

namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample
{
	public interface IMySampleButtonView : IView
    {
		IMySampleViewModel Model { get; set; }
    }
}
