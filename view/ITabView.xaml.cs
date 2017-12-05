using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;
using Genesyslab.Desktop.Modules.Windows.Event;
using System.Windows;
using Genesyslab.Desktop.WPFCommon.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.views
{
    public partial class ITabView :  IITabView
    {
        readonly IObjectContainer container;
        readonly IViewEventManager viewEventManager;

        public ITabView(IITabViewModel viewModel, IObjectContainer container, IViewEventManager viewEventManager)
        {
            this.container = container;
            this.viewEventManager = viewEventManager;
            this.Model = viewModel;

            InitializeComponent();

            Width = Double.NaN;
            Height = Double.NaN;
        }


        public object Context { get; set; }

        public void Create()
        {
            Model.Case = (Context as IDictionary<string, object>).TryGetValue("Case") as ICase;

            // viewEventManager.Subscribe(ActionEventHandler);
        }

        public void Destroy()
        {
            // viewEventManager.Unsubscribe(ActionEventHandler);

            Model.Case = null;
        }


        public IITabViewModel Model
        {
            get { return this.DataContext as IITabViewModel; }
            set { this.DataContext = value; }
        }

    }
}
