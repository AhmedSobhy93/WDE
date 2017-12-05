using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;
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
using System.Windows.Threading;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication
{
    /// <summary>
    /// Interaction logic for MySampleButtonViewHLRBKC.xaml
    /// </summary>
    public partial class MySampleButtonViewHLRBKC : UserControl, IMySampleButtonViewHLRBKC
    {
        readonly IObjectContainer container;
        readonly IViewEventManager viewEventManager;

        public MySampleButtonViewHLRBKC(IMySampleViewModelHLRBKC viewModel, IObjectContainer container, IViewEventManager viewEventManager)
        {
            this.container = container;
            this.viewEventManager = viewEventManager;
            this.Model = viewModel;
            InitializeComponent();

            Width = Double.NaN;
            Height = Double.NaN;
        }

        #region IView Members

        public object Context { get; set; }

        public void Create()
        {
            Model.Case = (Context as IDictionary<string, object>).TryGetValue("Case") as ICase;

            viewEventManager.Subscribe(ActionEventHandler);
        }

        public void Destroy()
        {
            viewEventManager.Unsubscribe(ActionEventHandler);

            Model.Case = null;
        }

        #endregion

        #region IMainToolbarContainerView Members
        public IMySampleViewModelHLRBKC Model
        {
            get { return this.DataContext as IMySampleViewModelHLRBKC; }
            set { this.DataContext = value; }
        }

        #endregion

        public void ActionEventHandler(object eventObject)
        {
            //MessageBox.Show(phone.phoneNumber.ToString());

            if (Application.Current.Dispatcher != null && !Application.Current.Dispatcher.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action<object>(ActionEventHandler), eventObject);
            else
            {
                GenericEvent contactEvent = eventObject as GenericEvent;

                if (contactEvent != null && contactEvent.Context == Model.Case.CaseId &&
                    contactEvent.Target == GenericContainerView.ContainerView)
                {
                    foreach (GenericAction contactAction in contactEvent.Action)
                    {
                        string objectSimpleAction = contactAction.Action as string;
                        switch (objectSimpleAction)
                        {
                            // To use a 8.1.3.x plug-in with IW 8.1.3, use the following block
                            // case ActionGenericContainerView.ShowHidePanelRight:
                            //     splitToggleButton.IsChecked = ((Visibility)contactAction.Parameters[0] == Visibility.Visible && contactAction.Parameters[1] as string == "MyInteractionSample");
                            //     break;
                            //
                            // for use with IW 8.1.4+ to synchronize the side button with the visibility of the right panel 
                            case ActionGenericContainerView.UserControlLoaded:
                                splitToggleButton.IsChecked = ((Visibility)contactAction.Parameters[0] == Visibility.Visible && contactAction.Parameters[1] as string == "MyInteractionSample");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void splitbutton(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(phone.phoneNumber.ToString());
            // Lock MinSize
            viewEventManager.Publish(new GenericEvent()
            {
                SourceId = null,
                Target = GenericContainerView.ContainerView,
                Context = Model.Case.CaseId,
                TargetId = null,
                Action = new GenericAction[]
                {
                    new GenericAction ()
                    {
                        Action = ActionGenericContainerView.LockMinSize,
                        Parameters = new object[] { true, "InteractionContainerView" }
                    }
                }
            });

            viewEventManager.Publish(new GenericEvent()
            {
                Target = GenericContainerView.ContainerView,
                Context = Model.Case.CaseId,
                Action = new GenericAction[]
                {
                    new GenericAction ()
                    {
                        Action = ActionGenericContainerView.ShowHidePanelRight,
                        Parameters = new object[] { splitToggleButton.IsChecked ?? false ? Visibility.Visible : Visibility.Collapsed, "MyInteractionSample" }
                    },
                    new GenericAction ()
                    {
                        Action = ActionGenericContainerView.ActivateThisPanel,
                        Parameters = new object[] { "MyInteractionSampleHLRBKC" }
                    }
                }
            });

            // Unlock MinSize
            viewEventManager.Publish(new GenericEvent()
            {
                SourceId = null,
                Target = GenericContainerView.ContainerView,
                Context = Model.Case.CaseId,
                TargetId = null,
                Action = new GenericAction[]
                {
                    new GenericAction ()
                    {
                        Action = ActionGenericContainerView.LockMinSize,
                        Parameters = new object[] { false, "InteractionContainerView"  }
                    }
                }
            });
        }
    }
}
