using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.Windows.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Genesyslab.Desktop.Modules.ExtensionSample.XDR_View_BKC_Application
{
    /// <summary>
    /// Interaction logic for MySampleMenuViewHLRXDRViewBKC.xaml
    /// </summary>
    public partial class MySampleMenuViewHLRXDRViewBKC : MenuItem, IMyExtensionSampleViewXDRViewBKC
    {

        readonly IObjectContainer container;
        readonly IViewEventManager viewEventManager;

        public MySampleMenuViewHLRXDRViewBKC(IObjectContainer container, IViewEventManager viewEventManager)
        {
            this.container = container;
            this.viewEventManager = viewEventManager;
            InitializeComponent();
            Width = Double.NaN;
            Height = Double.NaN;
        }

        private void menuitem(object sender, RoutedEventArgs e)
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
                            Parameters = new object[] { "MySampleXDRViewBKC" }
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
