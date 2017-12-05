using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;
using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication;
using Genesyslab.Desktop.Modules.Windows.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Genesyslab.Desktop.Modules.ExtensionSample.HLR_BKC_Application
{
    /// <summary>
    /// Interaction logic for MySampleMenuViewHLRBKC.xaml
    /// </summary>
    public partial class MySampleMenuViewHLRBKC : MenuItem, IMyExtensionSampleViewHLRBKC
    {
        readonly IObjectContainer container;
        readonly IViewEventManager viewEventManager;
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);

        public MySampleMenuViewHLRBKC(IObjectContainer container, IViewEventManager viewEventManager)
        {
            //MessageBox.Show("MySampleMenuViewHLRBKC  Item Clicked HLR");
            this.container = container;
            this.viewEventManager = viewEventManager;
            InitializeComponent();
            Width = Double.NaN;
            Height = Double.NaN;
        }

        private void menuitem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item Clicked HLR BKC");
          
            if (MySampleViewHLRBKC.cookiesListHLRBKC != null)
            {
                bool isEmpty = (MySampleViewHLRBKC.cookiesListHLRBKC.Count == 0);

                if (!isEmpty && MySampleViewHLRBKC.cookiesListHLRBKC.Contains("PHPSESSID"))
                {
                    MessageBox.Show("Cookie Here, It's looged in ");

                }
            }

            
            viewEventManager.Publish(new GenericEvent()
            {

                Target = GenericContainerView.ContainerView,
                Context = "ToolbarWorkplace",

                Action = new GenericAction[]
                  {
                      
                        new GenericAction ()
                        {
                            Action = ActionGenericContainerView.ActivateThisPanel,
                            Parameters = new object[] { "MySampleHLRBKC" }
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

        //public void checkChookie()
        //{
        //    if (MySampleViewHLRBKC.cookiesListHLRBKC != null)
        //    {
        //        bool isEmpty = (MySampleViewHLRBKC.cookiesListHLRBKC.Count == 0);
        //        if (!isEmpty && MySampleViewHLRBKC.cookiesListHLRBKC.Contains("PHPSESSID"))
        //        {

        //            MessageBox.Show("Looged In");
        //            if (CTICommands.phoneNumber != null)
        //            {
        //                MessageBox.Show("Have a call");
        //                string postData = "number= " + /*CTICommands.phoneNumber*/ "555902585";
        //                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        //                byte[] bytes = encoding.GetBytes(postData);
        //                string url = " http://azerfon-oss.azerfon.az/tools/hlr_lookup_cc/lib/backend.php";
        //                string headers = "Content-Type: application/x-www-form-urlencoded";
        //                InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

        //                foreach (DictionaryEntry cookie in MySampleViewHLRBKC.cookiesListHLRBKC)
        //                {
        //                    string key = cookie.Key.ToString();
        //                    string value = cookie.Value.ToString();

        //                    InternetSetCookie(url, key, value);

        //                }
        //                zedApplicationLink.Navigate(url, "", bytes, headers);
        //            }
        //            else
        //            {
        //                MessageBox.Show("NOt have a call but looged in show him HLR lookup");
        //            http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/

        //                this.Model = mySampleViewModel;
        //                InitializeComponent();
        //                HideScriptErrors(zedApplicationLink, true);
        //                currentUri = new UriBuilder("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/").Uri;
        //                zedApplicationLink.Source = currentUri;
        //                zedApplicationLink.Navigating += new NavigatingCancelEventHandler(myBrowser_Navigating);
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("login page");
        //        this.Model = mySampleViewModel;
        //        InitializeComponent();
        //        HideScriptErrors(zedApplicationLink, true);
        //        currentUri = new UriBuilder("http://azerfon-oss.azerfon.az/users/login.php").Uri;
        //        zedApplicationLink.Source = currentUri;
        //        zedApplicationLink.Navigating += new NavigatingCancelEventHandler(myBrowser_Navigating);
        //    }
        //    Width = Double.NaN;
        //    Height = Double.NaN;
        //    MinSize = new MSize() { Width = 400.0, Height = 400.0 };
        //}
        

    }
}
