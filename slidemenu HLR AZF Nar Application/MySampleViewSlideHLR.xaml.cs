using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;
using Genesyslab.Desktop.Modules.ExtensionSample.HLR_AZF_Nar_Application;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_AZF_Nar_Application
{
    /// <summary>
    /// Interaction logic for MySampleViewSlideHLR.xaml
    /// </summary>
    public partial class MySampleViewSlideHLR : UserControl, IMySampleViewSlideHLR 
    {
        

        //public static Uri currentUriHLRNar;

        readonly IObjectContainer container;
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);
        public static OrderedDictionary cookiesListHLRNar = null;



        public MySampleViewSlideHLR(IMySampleViewModelSlideHLR mySampleViewModel, IObjectContainer container)
        {
            MessageBox.Show("My Sample View  HLR nar");

            //this.Model = mySampleViewModel;
            //this.container = container;
            //InitializeComponent();
            ////HideScriptErrors(zedApplicationLink, true);
            //var link = new UriBuilder("http://azerfon-oss.azerfon.az/users/login.php").Uri;
            //zedApplicationLink.Source = link;
            //MessageBox.Show("HLR nar Source " + link);
            ////prePostRequest();
            ////postrequest();
            ////post();
            ////Width = Double.NaN;
            ////Height = Double.NaN;
            ////MinSize = new MSize() { Width = 400.0, Height = 400.0 };

            this.Model = mySampleViewModel;
            this.container = container;
            InitializeComponent();
            HideScriptErrors(zedApplicationLink, true);

            prePostRequest();
            postrequest();
            //postrequest();
            Width = Double.NaN;
            Height = Double.NaN;
            MinSize = new MSize() { Width = 400.0, Height = 400.0 };
        }

        //private void postrequest()
        //{
        //    //try
        //    //{
        //    //    string postData = "msisdn_text=" + /*CTICommands.phoneNumber*/"776480368";
        //    //    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        //    //    byte[] bytes = encoding.GetBytes(postData);
        //    //    string urlafterlogin = "http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php";
        //    //    MessageBox.Show(cookieHLRName.ToString());
        //    //    MessageBox.Show(cookieHLRValue.ToString());
        //    //    Cookie temp1 = new Cookie(cookieHLRName, cookieHLRValue, "azf-oss-tools.azerconnect.az", "/");

        //    //    //InternetSetCookie(urlafterlogin, cookieHLRName, cookieHLRValue);
        //    //    //InternetSetCookie("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php", cookieHLRName, cookieHLRValue);
        //    //    //InternetSetCookie("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php", null, temp1.ToString() + "; Expires=Tue, 19 Jan 2038 03:14:07 GMT;");
        //    //    InternetSetCookieEx("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php", null, cookieHLRName+"="+cookieHLRName+";", 0, 0);

        //    //    zedApplicationLink.Navigate(urlafterlogin, "", bytes, "" );
        //    //}
        //    //catch(Exception e)
        //    //{
        //    //    MessageBox.Show(e.ToString());
        //    //}

        //    try{
        //        string postData = "msisdn_text= " + /*CTICommands.phoneNumber*/ "704020269";
        //        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        //        byte[] bytes = encoding.GetBytes(postData);

        //               //     http://azerfon-oss.azerfon.az/tools/hlr_lookup/lib/results.php  

        //        string url = "http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php";
        //        MessageBox.Show(url);
        //        string headers = "Content-Type: application/x-www-form-urlencoded";
        //        //InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

        //        foreach (DictionaryEntry cookie in cookiesListHLRNar)
        //        {
                
        //            string key = cookie.Key.ToString();
        //            MessageBox.Show("Cookies HLR NAr key:-" + key);
        //            string value = cookie.Value.ToString();
        //            MessageBox.Show("Cookies HLR NAr value:-" + value);

        //            InternetSetCookie(url, key, value);

        //        }
        //        zedApplicationLink.Navigate(url, "", bytes, headers);

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }

        //}

        public void postrequest()
        {
            string postData = "msisdn_text= " + /*CTICommands.phoneNumber*/ "704020269";
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(postData);
            string url = " http://azerfon-oss.azerfon.az/tools/hlr_lookup/lib/results.php";
            string headers = "Content-Type: application/x-www-form-urlencoded";
            //InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

            foreach (DictionaryEntry cookie in cookiesListHLRNar)
            {
                string key = cookie.Key.ToString();
                string value = cookie.Value.ToString();

                InternetSetCookie(url, key, value);

            }
            zedApplicationLink.Navigate(url, "", bytes, headers);
        }

        //private void post()
        //{
        //    try
        //    {
        //        var request = (HttpWebRequest)WebRequest.Create("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php");

        //        Uri myUri = new Uri("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php");
        //        string host = myUri.Host;  // host is "www.contoso.com"

        //        var postData = "msisdn_text=776480368";
        //        var data = Encoding.ASCII.GetBytes(postData);

        //        request.Method = "POST";
        //        request.CookieContainer = new CookieContainer();
        //        //MessageBox.Show(cookieHLRName.ToString());
        //        //MessageBox.Show(cookieHLRValue.ToString());
        //        //request.CookieContainer.Add(new Cookie(cookieHLRName, cookieHLRValue, "/", ".azf-oss-tools.azerconnect.az"));
        //        request.CookieContainer.Add(new Uri("http://azf-oss-tools.azerconnect.az/tools/hlr_lookup/lib/results.php"), new Cookie(cookieHLRName.ToString(), cookieHLRValue.ToString()));
        //        //request.Headers.Add("Cookie", cookieHLRName + "=" + cookieHLRValue);
        //        //request.ContentType = "application/x-www-form-urlencoded";
        //        request.ContentLength = data.Length;
        //        using (var stream = request.GetRequestStream())
        //        {
        //            stream.Write(data, 0, data.Length);
        //        }
        //        var response = (HttpWebResponse)request.GetResponse();
        //        Stream receiveStream = response.GetResponseStream();

        //        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //        MessageBox.Show(responseString.ToString());
        //        zedApplicationLink.NavigateToStream(receiveStream);

        //    }
        //    catch(Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //}

        void prePostRequest()
        {
            //string url = MySampleViewPageHLR.currentUri.ToString();
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.CookieContainer = new CookieContainer();
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            //MessageBox.Show(response.Cookies.ToString());
            //int count = response.Cookies.Count;
            //foreach (Cookie cookie in response.Cookies)
            //{
            //    MessageBox.Show(cookie.Name.ToString());
            //    MessageBox.Show(cookie.Value.ToString());
            //    cookieHLRName = cookie.Name.ToString();
            //    cookieHLRValue = cookie.Value.ToString();
            //}


            cookiesListHLRNar = new OrderedDictionary();
            string url = MySampleViewPageHLR.currentUri.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            MessageBox.Show(response.Cookies.ToString());
            int count = response.Cookies.Count;
            foreach (Cookie cookie in response.Cookies)
            {
                MessageBox.Show("HLR BKC Name Cookie:-" + cookie.Name.ToString());
                MessageBox.Show("HLR BKC Value Cookie:-" + cookie.Value.ToString());
                //cookieHLRName = cookie.Name.ToString();
                //cookieHLRValue = cookie.Value.ToString();
                cookiesListHLRNar.Add(cookie.Name.ToString(), cookie.Value.ToString());
            }
        }



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
        #region IMySampleView Members

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public IMySampleViewModelSlideHLR Model
        {
            get { return this.DataContext as IMySampleViewModelSlideHLR; }
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
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy()
        {
        }

        #endregion

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Model.ResetCounter();
        }

        private void MySampleView_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}
