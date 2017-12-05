using System;
using System.Windows;
using System.Windows.Controls;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.Windows.Event;

namespace Genesyslab.Desktop.Modules.ExtensionSample.MySample
{
	/// <summary>
	/// Interaction logic for MySampleMenuView.xaml
	/// This view allows to add a menu entry into the DropDownButton "Workspace in the MainWindows"
	/// </summary>
	public partial class MySampleMenuView : MenuItem, IMySampleMenuView
	{
		readonly IObjectContainer container;
		readonly IViewEventManager viewEventManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="MySampleMenuView"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		public MySampleMenuView(IObjectContainer container, IViewEventManager viewEventManager)
		{
			this.container = container;
			this.viewEventManager = viewEventManager;

			InitializeComponent();

			Width = Double.NaN;
			Height = Double.NaN;
		}

		private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            viewEventManager.Publish(new GenericEvent()
			{
				Target = GenericContainerView.ContainerView,
				Context = "ToolbarWorkplace",

                Action = new GenericAction[]
					{
						new GenericAction ()
						{
							Action = ActionGenericContainerView.ActivateThisPanel,
							Parameters = new object[] { "MySample" }
						}
					}
			});

			// Show and active the MyWorkplace view in the ToolbarWorksheet region
			viewEventManager.Publish(new GenericEvent()
			{
				Target = GenericContainerView.ContainerView,
				Context = "ToolbarWorksheet",
				Action = new GenericAction[]
					{
						new GenericAction ()
						{
							Action = ActionGenericContainerView.ShowHidePanelRight,
							Parameters = new object[] { Visibility.Visible, "MyWorkplaceContainerView" }
						},
						new GenericAction ()
						{
							Action = ActionGenericContainerView.ActivateThisPanel,
							Parameters = new object[] { "MyWorkplaceContainerView" }
						}
					}
			});
		}
	}
}
