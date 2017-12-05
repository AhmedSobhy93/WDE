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

namespace Genesyslab.Desktop.Modules.ExtensionSample.APEX_BKC_Application
{
    /// <summary>
    /// Interaction logic for MySampleMenuViewApexBKC.xaml
    /// </summary>
    public partial class MySampleMenuViewApexBKC : MenuItem, IMyExtensionSampleViewApexBKC
    {
        readonly IObjectContainer container;
        readonly IViewEventManager viewEventManager;
        public MySampleMenuViewApexBKC(IObjectContainer container, IViewEventManager viewEventManager)
        {
            this.container = container;
            this.viewEventManager = viewEventManager;
            InitializeComponent();
            Width = Double.NaN;
            Height = Double.NaN;
        }

        private void meueItem(object sender, RoutedEventArgs e)
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
                            Parameters = new object[] { "MySampleApexBKC" }
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
