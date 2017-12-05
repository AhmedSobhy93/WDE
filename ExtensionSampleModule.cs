using Genesyslab.Desktop.Infrastructure.Commands;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Infrastructure.ViewManager;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;
using Genesyslab.Desktop.Modules.ExtensionSample.MySample;
//using Microsoft.Practices.Composite.Modularity;
using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Event;
using System.Windows;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;
using Genesyslab.Platform.Commons.Logging;
using Genesyslab.Desktop.Modules.Core.Model.Agents;
using System;
using Genesyslab.Platform.Commons.Protocols;
using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel.CfgObjects;
using Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample;
using Genesyslab.Desktop.Modules.ExtensionSample.Huawei_CRM_AZF_Nar;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Huawei_CRM_AZF_Nar;
using Genesyslab.Desktop.Modules.ExtensionSample.Cube_application;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Cube_Appplication;
using Genesyslab.Desktop.Modules.ExtensionSample.HLR_AZF_Nar_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_AZF_Nar_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.APEX_AZF_Nar_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.APEX_AZF_Fixed_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.Huawei_CRM_BKC_Application;
using System.Linq;
using Genesyslab.Desktop.Modules.ExtensionSample.XDR_View_BKC_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.HLR_BKC_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.APEX_BKC_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_ApexBKC;
using System.Collections.Generic;
using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel;
using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel.Queries;


using Genesyslab.Platform.ApplicationBlocks.Commons.Protocols;
using Genesyslab.Platform.ApplicationBlocks.WarmStandby;
using Genesyslab.Platform.Configuration.Protocols;
using Genesyslab.Platform.Configuration.Protocols.Types;
using Genesyslab.Platform.Commons.Connection.Configuration;


//using Genesyslab.Desktop.Modules.ExtensionSample.views;

namespace Genesyslab.Desktop.Modules.ExtensionSample
{


    /// <summary>
    /// This class is a sample module which shows several ways of customization
    /// </summary>
    public class ExtensionSampleModule : IModule
	{
        public string agentProfile = "";
        public static string agentDN ="";
        readonly IObjectContainer container;
		readonly IViewManager viewManager;
		readonly ICommandManager commandManager;
		readonly IViewEventManager viewEventManager;
        readonly IInteractionManager interactionManager;
        ILogger LOGGER = ContainerAccessPoint.Container.Resolve<ILogger>();
        //private IConfService confService;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionSampleModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="viewManager">The view manager.</param>
        /// <param name="commandManager">The command manager.</param>
        public ExtensionSampleModule(IObjectContainer container, IViewManager viewManager, IInteractionManager interactionManager , ICommandManager commandManager, IViewEventManager viewEventManager)
		{
			this.container = container;
			this.viewManager = viewManager;
			this.commandManager = commandManager;
			this.viewEventManager = viewEventManager;
            this.interactionManager = interactionManager;
        }

        /// <summary>
        /// Initializes the module.
        /// </summary>
        /// 

        public void Initialize()
        {
            //agentDNs();
            confserv();
            //cti.Register();
            InitializeViews();

        }

        //private void agentDNs()
        //{
        //    IAgent agentID = container.Resolve<IAgent>();
        //    agentDN = agentID.Place.ConfPlace.DNs.FirstOrDefault().Number;
        //    MessageBox.Show(agentDN);
        //}
        public void InitializeViews()
		{
            //bool AZFNar = true;
            //IAgent agent = container.Resolve<IAgent>();
            //MessageBox.Show(agent.AgentGroupsForAgent[0].DBID.ToString());
            //string agentProfile = agent.AgentGroupsForAgent[0].ObjectDbid.ToString();
            //MessageBox.Show(agent.AgentGroupsForAgent[0].ObjectDbid.ToString());
            //MessageBox.Show(agent.);
            //Nar Tab 

            MessageBox.Show("agentProfile >>"+agentProfile);
            if (agentProfile.Equals("Azf_Nar"))
            {
                HuaweiCRMAZFNartab1();
                ZedApplicationtab2();
                CubeApplicationtab3();
                HLRAZFNARtab4();
                slidemenuHLRAZFNARApplicatio4();
                ApexAzfNartab5();
                slidemenuAPEXNARApplicatio3();
            }
            else if (agentProfile.Equals("Azf_Fixed"))
            {
                ApexAzfFixedtab1();
                slidemenuAPEXAZFFIXEDApplicatio2();
            }
            else if (agentProfile.Equals("Backcell"))
            {
                HuaweiCRMBKC();
                // huawei slide menu
                slidemenuXDRviewBKC();
                XDRViewBKCtab();
                slidemenuHLRBKC();
                HLRBKCTab();
                slidemenuApexBKC();
                APEXBKCTab();
            }
            // Event registration
            // Subscribe to the post login / post logout events
            viewEventManager.Subscribe(MyEventHandler);
		}

        private void slidemenuApexBKC()
        {
            //// will open in side menu 

            // APEX nar POPUP

            // Here we register the view (GUI) "IMySampleView" and its behavior counterpart "IMySampleViewModel"
            container.RegisterType<IMySampleViewApexBKC, MySampleViewApexBKC>();
            container.RegisterType<IMySampleViewModelApexBKC, slidemenu_ApexBKC.MySampleViewModelApexBKC>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleViewApexBKC), ViewName = "MyInteractionSampleApexBKC", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IMySampleButtonViewApexBKC, MySampleButtonViewApexBKC>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleButtonViewApexBKC), ViewName = "MyButtonViewApexBKC", ActivateView = true }
            );
        }
      
        private void slidemenuHLRBKC()
        {
            //// will open in side menu 

            // Add a view in the right panel in the interaction window

            // Here we register the view (GUI) "IMySampleView" and its behavior counterpart "IMySampleViewModel"
            container.RegisterType<IMySampleViewHLRBKC, MySampleViewHLRBKC>();
            container.RegisterType<IMySampleViewModelHLRBKC, slidemenu_HLR_BKC_Appplication.MySampleViewModelHLRBKC>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleViewHLRBKC), ViewName = "MyInteractionSampleHLRBKC", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IMySampleButtonViewHLRBKC, MySampleButtonViewHLRBKC>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleButtonViewHLRBKC), ViewName = "MyButtonViewHLRBKC", ActivateView = true }
            );
        }

        private void APEXBKCTab()
        {
            container.RegisterType<IMySampleMenuViewApexBKC, MySampleViewPageApexBKC>();
            container.RegisterType<IMyExtensionSampleViewModelApexBKC, APEX_BKC_Application.MySampleViewModelApexBKC>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(3,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewApexBKC), ViewName = "MySampleApexBKC" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewApexBKC, MySampleMenuViewApexBKC>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(3,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewApexBKC), ViewName = "MySampleMenuApexBKC", ActivateView = true });
        }

        private void HuaweiCRMAZFNartab1()
        {
            //Huawei CRM
            container.RegisterType<IextensionSampleView, Huawei_CRM_AZF_Nar.sampleView>();
            container.RegisterType<IextensionSampleViewModel, samplePresentationModel>();

            // Put the MySample view in the region "ToolbarWorkplaceRegion" (The TabControl in the main toolbar)
            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(0,
                new ViewActivator() { ViewType = typeof(IextensionSampleView), ViewName = "Huawei_CRM_AZF_Nar" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IsampleMenuView, sampleMenuView>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(0,
                new ViewActivator() { ViewType = typeof(IsampleMenuView), ViewName = "MyMenu", ActivateView = true });

        }
        private void slidemenuXDRviewBKC()
        {
            //// will open in side menu 

            // Add a view in the right panel in the interaction window

            // Here we register the view (GUI) "IMySampleView" and its behavior counterpart "IMySampleViewModel"
            container.RegisterType<IsampleView, slidemenu_Huawei_CRM_AZF_Nar.sampleView>();
            container.RegisterType<IsampleViewModel, sampleViewModel>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IsampleView), ViewName = "MyInteractionSampleHuawei", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IsampleButtonView, sampleButtonView>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IsampleButtonView), ViewName = "MyButtonView", ActivateView = true }
            );
        }
        private void ZedApplicationtab2()
        {
            //Here we register the view(GUI) "IMySampleView" and its behavior counterpart "IMySamplePresentationModel"
            container.RegisterType<IMyExtensionSampleView, MySample.MySampleView>();
            container.RegisterType<IMyExtensionSampleViewModel, MySample.MySampleViewModel>();

            // Put the MySample view in the region "ToolbarWorkplaceRegion" (The TabControl in the main toolbar)
            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(1,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleView), ViewName = "MySample" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMySampleMenuView, MySampleMenuView>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(1,
                new ViewActivator() { ViewType = typeof(IMySampleMenuView), ViewName = "MySampleMenu", ActivateView = true });

        }
        private void slidemenuAPEXAZFFIXEDApplicatio2()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// will open in side menu 

            // Add a view in the right panel in the interaction window

            // Here we register the view (GUI) "IMySampleView" and its behavior counterpart "IMySampleViewModel"
            container.RegisterType<IMySampleView, InteractionExtensionSample.MySample.MySampleView>();
            container.RegisterType<IMySampleViewModel, InteractionExtensionSample.MySample.MySampleViewModel>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleView), ViewName = "MyInteractionSample", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IMySampleButtonView, MySampleButtonView>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleButtonView), ViewName = "MySampleButtonZed", ActivateView = true }
            );
        }
        private void CubeApplicationtab3()
        {
            //cube application
            container.RegisterType<extensionSampleViewCube, sampleViewCubeModel>();
            container.RegisterType<sampleViewModelCube, Cube_application.MySampleViewModelCube>();

            // Put the MySample view in the region "ToolbarWorkplaceRegion" (The TabControl in the main toolbar)
            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(3,
                new ViewActivator() { ViewType = typeof(extensionSampleViewCube), ViewName = "Cube Application" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<sampleMenuViewCubeinterface, sampleMenuViewCube>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(3,
                new ViewActivator() { ViewType = typeof(sampleMenuViewCubeinterface), ViewName = "Cube Menu", ActivateView = true });

        }
        private void slidemenuAPEXNARApplicatio3()
        {
            //// will open in side menu 

            // APEX nar POPUP
            MessageBox.Show("APEX Pop Up");
            // Here we register the view (GUI) "IMySampleView" and its behavior counterpart "IMySampleViewModel"
            container.RegisterType<IMySampleViewCube , MySampleViewCube>();
            container.RegisterType<IMySampleViewModelCube, slidemenu_Cube_Appplication.MySampleViewModelCube>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleViewCube), ViewName = "MyInteractionSampleCube", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IMySampleButtonViewCube, MySampleButtonViewCube>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleButtonViewCube), ViewName = "MyButtonViewCube", ActivateView = true }
            );
        }
        private void HLRAZFNARtab4()
        {
            container.RegisterType<IMySampleMenuViewHLR, MySampleViewPageHLR>();
            container.RegisterType<IMyExtensionSampleViewModelHLR, MySampleViewModelHLR>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(4,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewHLR), ViewName = "MySampleHLR" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewHLR, MySampleMenuViewHLR>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(4,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewHLR), ViewName = "MySampleMenuHLR", ActivateView = true });


        }
        private void HuaweiCRMBKC()
        {
            container.RegisterType<IMySampleMenuViewHuaweiCRMBKC, MySampleViewPageHuaweiCRMBKC>();
            container.RegisterType<IMyExtensionSampleViewModelHuaweiCRMBKC, MySampleViewModelHuaweiCRMBKC>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(0,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewHuaweiCRMBKC), ViewName = "MySampleHuaweiCRMBKC" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewHuaweiCRMBKC, MySampleMenuViewHuaweiCRMBKC>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(0,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewHuaweiCRMBKC), ViewName = "MySampleMenuHuaweiCRMBKC", ActivateView = true });


        }

        private void XDRViewBKCtab ()
        {
            container.RegisterType<IMySampleMenuViewXDRViewBKC, MySampleViewPageXDRViewBKC>();
            container.RegisterType<IMyExtensionSampleViewModelXDRViewBKC, MySampleViewModelXDRViewBKC>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(1,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewXDRViewBKC), ViewName = "MySampleXDRViewBKC" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewXDRViewBKC, MySampleMenuViewHLRXDRViewBKC>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(1,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewXDRViewBKC), ViewName = "MySampleMenuXDRViewBKC", ActivateView = true });

        }

        private void HLRBKCTab()
        {
            MessageBox.Show(" HLRBKCTab 1");
            container.RegisterType<IMySampleMenuViewHLRBKC, MySampleViewPageHLRBKC>();
            container.RegisterType<IMyExtensionSampleViewModelHLRBKC, HLR_BKC_Application.MySampleViewModelHLRBKC>();

            MessageBox.Show(" HLRBKCTab 2");
            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(2,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewHLRBKC), ViewName = "MySampleHLRBKC" });

            MessageBox.Show(" HLRBKCTab 3");
            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewHLRBKC, MySampleMenuViewHLRBKC>();

            MessageBox.Show(" HLRBKCTab 4");
            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(2,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewHLRBKC), ViewName = "MySampleMenuHLRBKC", ActivateView = true });

        }

        private void slidemenuHLRAZFNARApplicatio4()
        {
            MessageBox.Show("HLR Pop Up");
            container.RegisterType<IMySampleViewSlideHLR, MySampleViewSlideHLR>();
            container.RegisterType<IMySampleViewModelSlideHLR, MySampleViewModelSlideHLR>();

            // Put the MySample view in the region "InteractionWorksheetRegion"
            viewManager.ViewsByRegionName["InteractionWorksheetRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleViewSlideHLR), ViewName = "MyInteractionSampleHLR", ActivateView = true }
            );

            // Here we register the view (GUI) "IMySampleButtonView"
            container.RegisterType<IMySampleButtonViewSlideHLR, MySampleButtonViewSlideHLR>();

            // Put the MySampleMenuView view in the region "CaseViewSideButtonRegion" (The case toggle button in the interaction windows)
            viewManager.ViewsByRegionName["CaseViewSideButtonRegion"].Add(
                new ViewActivator() { ViewType = typeof(IMySampleButtonViewSlideHLR), ViewName = "MyButtonViewHLR", ActivateView = true }
            );
        }
        private void ApexAzfNartab5()
        {
            container.RegisterType<IMySampleMenuViewApex, MySampleViewPageApex>();
            container.RegisterType<IMyExtensionSampleViewModelApex, MySampleViewModelApex>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(5,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewApex), ViewName = "MySampleApex" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewApex, MySampleMenuViewApex>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(5,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewApex), ViewName = "MySampleMenuApexFixed", ActivateView = true });


        }

       private void ApexAzfFixedtab1 ()
        {
            container.RegisterType<IMySampleMenuViewApexFixed, MySampleViewPageApexFixed>();
            container.RegisterType<IMyExtensionSampleViewModelApexFixed, MySampleViewModelApexFixed>();

            viewManager.ViewsByRegionName["ToolbarWorkplaceRegion"].Insert(0,
               new ViewActivator() { ViewType = typeof(IMySampleMenuViewApexFixed), ViewName = "MySampleApexFixed" });

            // Here we register the view (GUI) "IMySampleMenuView"
            container.RegisterType<IMyExtensionSampleViewApexFixed, MySampleMenuViewApexFixed>();

            // Put the MySampleMenuView view in the region "WorkspaceMenuRegion" (The Workspace toggle button in the main toolbar)
            viewManager.ViewsByRegionName["WorkspaceMenuRegion"].Insert(0,
                new ViewActivator() { ViewType = typeof(IMyExtensionSampleViewApexFixed), ViewName = "MySampleMenuApexFixed", ActivateView = true });

        }

        private void InitializeAgentInformation()
        {
            IAgent agents = container.Resolve<IAgent>();
            agentDN = agents.Place.ConfPlace.DNs.FirstOrDefault().Number;
            MessageBox.Show(agentDN);
            CTICommands cti = new CTICommands();
            string Username = agents.UserName;
            string Password = agents.Password;
           
        }

        private void confserv()
        {           
            try
            {
                IAgent agent = container.Resolve<IAgent>();
                #region ADDP settings
                PropertyConfiguration config = new PropertyConfiguration();
                config.UseAddp = true;
                config.AddpServerTimeout = 30;
                config.AddpClientTimeout = 90;
                //config.AddpTrace = "both";
                config.AddpTraceMode = AddpTraceMode.Both;
                #endregion
                Endpoint endpoint = new Endpoint("10.220.57.1", 2020 );
                ConfServerProtocol confProtocol = new ConfServerProtocol(endpoint);
                confProtocol.ClientApplicationType = (int)CfgAppType.CFGSCE;
                confProtocol.ClientName = "default";
                confProtocol.UserName = agent.UserName;
                confProtocol.UserPassword = agent.Password;
                try
                {
                    confProtocol.BeginOpen();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                IConfService confservice = (ConfService)ConfServiceFactory.CreateConfService(confProtocol);

                CfgPersonQuery query = new CfgPersonQuery();
                query.UserName = agent.UserName;
                CfgPerson person = confservice.RetrieveObject<CfgPerson>(query);
                //MessageBox.Show(person.ToString());
                CfgAccessGroupQuery querys = new CfgAccessGroupQuery();
                querys.PersonDbid = person.DBID;
                querys.TenantDbid = 101;
                ICollection<CfgAccessGroup> accessGroups = confservice.RetrieveMultipleObjects<CfgAccessGroup>(querys);
                foreach (CfgAccessGroup accessGroup in accessGroups)
                {
                    agentProfile = accessGroup.GroupInfo.Name.ToString();
                    MessageBox.Show(agentProfile);

                    if (agentProfile.Equals("Azf_Nar"))
                    {
                        agentProfile = "Azf_Nar";
                        MessageBox.Show(agentProfile);
                        break;
                    }
                    else if (agentProfile.Equals("Azf_Fixed"))
                    {
                        agentProfile = "Azf_Fixed";
                        MessageBox.Show(agentProfile);
                        break;
                    }
                    else if (agentProfile.Equals("Backcell"))
                    {
                        agentProfile = "Backcell";
                        MessageBox.Show(agentProfile);
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        void MyEventHandler(object eventObject)
		{
			string eventMessage = eventObject as string;
			if (eventMessage != null)
			{
				switch (eventMessage)
				{
					case "Loggin":
                        MessageBox.Show("Post logged in");
                        InitializeAgentInformation();
                        break;
					case "Logout":
						MessageBox.Show("Post logged out");
						viewEventManager.Unsubscribe(MyEventHandler);
						break;
				}
			}
		}

        // not working i do not know why
       
        

    }
}
