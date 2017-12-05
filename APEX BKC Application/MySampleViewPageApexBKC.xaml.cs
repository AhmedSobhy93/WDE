using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

namespace Genesyslab.Desktop.Modules.ExtensionSample.APEX_BKC_Application
{
    /// <summary>
    /// Interaction logic for MySampleViewPageApexBKC.xaml
    /// </summary>
    public partial class MySampleViewPageApexBKC : UserControl, IMySampleMenuViewApexBKC
    {
        public static Uri currentUri;
        OrderedDictionary cookiesListApexBKC;

        //Source="http://callsapp.bakcell.com:8080/apex/f?p=102"
        public MySampleViewPageApexBKC(IMyExtensionSampleViewModelApexBKC mySampleViewModel)
        {
            this.Model = mySampleViewModel;
            InitializeComponent();
            HideScriptErrors(zedApplicationLink, true);
            currentUri = new UriBuilder("http://10.220.24.7:8080/apex/f?p=102").Uri;
            zedApplicationLink.Source = currentUri;
            zedApplicationLink.Navigating += new NavigatingCancelEventHandler(myBrowser_Navigating);
            
            //InitializeComponent();
            Width = Double.NaN;
            Height = Double.NaN;
            MinSize = new MSize() { Width = 400.0, Height = 400.0 };
        }

        void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (currentUri.AbsolutePath != e.Uri.AbsolutePath)
            {
                // Url has changed ...

                // Update current uri
                currentUri = e.Uri;
                //MessageBox.Show("myBrowser_Navigating e.uri >> "+e.Uri);
                //getCookies(e.Uri);
                

            }
        }
        //void getCookies(Uri uri)
        //{
        //    cookiesListApexBKC = new OrderedDictionary();

        //    string url = uri.ToString();
        //    MessageBox.Show("Pre POst REquest Apex BKC Tab" + url);

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
        //    request.CookieContainer = new CookieContainer();
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);

        //    int count = response.Cookies.Count;
        //    MessageBox.Show(response.Cookies.ToString() + " \n Tab Count>>" + count);
        //    foreach (Cookie cookie in response.Cookies)
        //    {
        //        MessageBox.Show("cookiesListApexBKC Tab" + cookie.Name.ToString());
        //        MessageBox.Show("cookiesListApexBKC Tab" + cookie.Value.ToString());
        //        cookiesListApexBKC.Add(cookie.Name.ToString(), cookie.Value.ToString());
        //    }
        //}



        #region IMySampleView Members

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public IMyExtensionSampleViewModelApexBKC Model
        {
            get { return this.DataContext as IMyExtensionSampleViewModelApexBKC; }
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

        //void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        //{
        //    String changedURL = e.Uri.AbsoluteUri.ToString();
        //    if (changedURL == targetStringToCompare)
        //    {
        //        MessageBox.Show(changedURL);
        //    }
        //}
    }
}
