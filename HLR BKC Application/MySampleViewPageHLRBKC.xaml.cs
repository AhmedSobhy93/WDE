using Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;

namespace Genesyslab.Desktop.Modules.ExtensionSample.HLR_BKC_Application
{
    /// <summary>
    /// Interaction logic for MySampleViewPageHLRBKC.xaml
    /// </summary>
    public partial class MySampleViewPageHLRBKC : UserControl, IMySampleMenuViewHLRBKC
    {
        public static Uri currentUri;
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);


        public MySampleViewPageHLRBKC(IMyExtensionSampleViewModelHLRBKC mySampleViewModel)
        {
            if (MySampleViewHLRBKC.cookiesListHLRBKC != null)
            {
                bool isEmpty = (MySampleViewHLRBKC.cookiesListHLRBKC.Count == 0);
                if (!isEmpty && MySampleViewHLRBKC.cookiesListHLRBKC.Contains("PHPSESSID"))
                {

                    MessageBox.Show("Looged In");
                    if (CTICommands.phoneNumber != null)
                    {
                        MessageBox.Show("Have a call");
                        string postData = "number= " + /*CTICommands.phoneNumber*/ "555902585";
                        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                        byte[] bytes = encoding.GetBytes(postData);
                        string url = " http://azerfon-oss.azerfon.az/tools/hlr_lookup_cc/lib/backend.php";
                        string headers = "Content-Type: application/x-www-form-urlencoded";
                        //InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

                        foreach (DictionaryEntry cookie in MySampleViewHLRBKC.cookiesListHLRBKC)
                        {
                            string key = cookie.Key.ToString();
                            string value = cookie.Value.ToString();

                            InternetSetCookie(url, key, value);

                        }
                        zedApplicationLink.Navigate(url, "", bytes, headers);
                    }
                    else
                    {
                        MessageBox.Show("NOt have a call but looged in show him HLR lookup");
                        //http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/

                        this.Model = mySampleViewModel;
                        InitializeComponent();
                        HideScriptErrors(zedApplicationLink, true);
                        currentUri = new UriBuilder("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/").Uri;
                        zedApplicationLink.Source = currentUri;
                        //zedApplicationLink.Navigating += new NavigatingCancelEventHandler(myBrowser_Navigating);
                    }

                }
            }
            else
            {
                MessageBox.Show("login page");
                this.Model = mySampleViewModel;
                InitializeComponent();
                HideScriptErrors(zedApplicationLink, true);
                currentUri = new UriBuilder("http://azerfon-oss.azerfon.az/users/login.php").Uri;
                zedApplicationLink.Source = currentUri;
                zedApplicationLink.Navigating += new NavigatingCancelEventHandler(myBrowser_Navigating);
            }
            Width = Double.NaN;
            Height = Double.NaN;
            MinSize = new MSize() { Width = 400.0, Height = 400.0 };
        }
        #region IMySampleView Members

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public IMyExtensionSampleViewModelHLRBKC Model
        {
            get { return this.DataContext as IMyExtensionSampleViewModelHLRBKC; }
            set { this.DataContext = value; }
        }


        #endregion

        #region IView Members

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public object Context { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        public void Create()
        {
            ObservableCollection<IMyListItem> collection = new ObservableCollection<IMyListItem>();
            //collection.Add(new MyListItem() { FirstName = "" });
            //collection.Add(new MyListItem() { LastName = "", FirstName = "" });

            Model.MyCollection = collection;
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy()
        {
        }

        #endregion
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                MessageBox.Show("Property Changed HLR BKC ");
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
        MSize _MinSize;

        public MSize MinSize
        {
            get { return _MinSize; }  // (MSize)base.GetValue(MinSizeProperty); }
            set
            {
                _MinSize = value; // base.SetValue(MinSizeProperty, value);
                OnPropertyChanged("MinSize");
            }
        }

        class MyListItem : IMyListItem
        {

            #region IMyListItem Members

            string lastName;
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    if (value != lastName) { lastName = value; OnPropertyChanged("LastName"); }
                }
            }

            #endregion

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }

            #endregion



        }
        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser)
                .GetField("_axIWebBrowser2",
                          BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember(
                "Silent", BindingFlags.SetProperty, null, objComWebBrowser,
                new object[] { Hide });
        }

       
        void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (currentUri.AbsolutePath != e.Uri.AbsolutePath)
            {
                // Url has changed ...

                // Update current uri
                currentUri = e.Uri;
                //zedApplicationLink.Source = currentUri;
            }
        }
    }
}
