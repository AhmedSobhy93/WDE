using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;
using Genesyslab.Desktop.Modules.ExtensionSample.HLR_BKC_Application;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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

namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_HLR_BKC_Appplication
{
    /// <summary>
    /// Interaction logic for MySampleViewHLRBKC.xaml
    /// </summary>
    /// 
    public partial class MySampleViewHLRBKC : UserControl, IMySampleViewHLRBKC
    {
          readonly IObjectContainer container;
          [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
          static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);
          public static OrderedDictionary cookiesListHLRBKC=null;


        public MySampleViewHLRBKC(IMySampleViewModelHLRBKC mySampleViewModel, IObjectContainer container)
        {

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

        private void post()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://10.64.38.79/hlr_cc/server-side/backend.php");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            //WRITE JSON DATA TO VARIABLE D
            string postData = "foo1=" + "aaAa";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "Content - Type: application / json \r\n";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            //zedApplicationLink.Navigate(response.ResponseUri);
            // Display the status.
            //            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            //zedApplicationLink.Navigate(dataStream);
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            zedApplicationLink.Navigate(dataStream.ToString());
            // Display the content.
            //MessageBox.Show(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }



        public void postrequest()
        {
            string postData = "number= " + /*CTICommands.phoneNumber*/ "555902585";
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(postData);
            string url = " http://azerfon-oss.azerfon.az/tools/hlr_lookup_cc/lib/backend.php";
            string headers = "Content-Type: application/x-www-form-urlencoded";
            //InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

            foreach (DictionaryEntry cookie in cookiesListHLRBKC)
            {
                string key=cookie.Key.ToString();
                string value = cookie.Value.ToString();

                InternetSetCookie(url, key, value);

            }
            zedApplicationLink.Navigate(url,"", bytes, headers);
        }

        void prePostRequest()
        {
            cookiesListHLRBKC = new OrderedDictionary();
            string url = MySampleViewPageHLRBKC.currentUri.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            MessageBox.Show(response.Cookies.ToString());
            int count = response.Cookies.Count;
            foreach (Cookie cookie in response.Cookies)
            {
                MessageBox.Show("HLR BKC Name Cookie:-"+cookie.Name.ToString());
                MessageBox.Show("HLR BKC Value Cookie:-"+cookie.Value.ToString());
                //cookieHLRName = cookie.Name.ToString();
                //cookieHLRValue = cookie.Value.ToString();
                cookiesListHLRBKC.Add(cookie.Name.ToString(), cookie.Value.ToString());
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

       
            //headers +=" User-Agent:  Mozilla/5.0" + "\r\n" + "Accept-Language  -  en-US,en;q=0.5 \r\n" ;


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
        public IMySampleViewModelHLRBKC Model
        {
            get { return this.DataContext as IMySampleViewModelHLRBKC; }
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
