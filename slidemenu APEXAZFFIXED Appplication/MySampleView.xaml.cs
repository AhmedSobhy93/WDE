using System;
using System.Windows.Controls;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System.ComponentModel;
using System.Windows;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using System.Reflection;
using Genesyslab.Desktop.Modules.ExtensionSample.APEX_AZF_Fixed_Application;
using Genesyslab.Desktop.Modules.ExtensionSample.Commands;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Collections;
using System.Net;

namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample
{
	/// <summary>
	/// Interaction logic for MySampleView.xaml
	/// </summary>
	public partial class MySampleView : UserControl, IMySampleView
	{
        string upadatedURL = "";
        readonly IObjectContainer container;
        public static Uri currentUriApexFixed;
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);
        public static OrderedDictionary cookiesListAPEXFixed = null;

        public MySampleView(IMySampleViewModel mySampleViewModel, IObjectContainer container )
		{
            //this.Model = mySampleViewModel;
            //this.container = container;

            //InitializeComponent();
            //HideScriptErrors(zedApplicationLink, true);
            //parsing();
            //currentUriApexFixed = new UriBuilder(upadatedURL).Uri;
            //zedApplicationLink.Source = currentUriApexFixed;

            MessageBox.Show("My Sample View Cube APEX nar");
            this.Model = mySampleViewModel;
            this.container = container;
            InitializeComponent();

            string newUrl = MySampleViewPageApexFixed.currentUri.ToString();
            MessageBox.Show(newUrl);
            string apexsessionID = getSessionId(newUrl);
            MessageBox.Show(apexsessionID);
            preGetRequest();
            getRequest(apexsessionID);

            HideScriptErrors(zedApplicationLink, true);
            Width = Double.NaN;
			Height = Double.NaN;
			MinSize = new MSize() { Width = 400.0, Height = 400.0 };
		}

        //public void parsing()
        //{
        //    int counter = 0;
        //    string sessionID = null;
        //    //http://callsapp:8080/apex/f?p=122:2:5900474262395793::NO
        //    //MySampleViewPageApex.currentUri.ToString();
        //    //http://callsapp:8080/apex/f?p=122:2:5900474262395793::NO::P2_MSISDN,P2_CALLID:994555902585,aaddffcc555
        //    string url = MySampleViewPageApexFixed.currentUri.ToString();
        //    if (url != null)
        //    {
        //        int indexofP = url.IndexOf("p=");
        //        //string sub = url.Substring(indexofP, url.Length);
        //        for (int i = indexofP; i < url.Length; i++)
        //        {
        //            if (url[i].ToString() == ":")
        //            {
        //                counter++;
        //            }
        //            if (counter == 2)
        //            {
        //                int number;
        //                if (true == int.TryParse(url[i].ToString(), out number))
        //                {
        //                    sessionID += url[i].ToString();
        //                }
        //            }
        //        }
        //    }
        //    upadatedURL = "http://callsapp:8080/apex/f?p=122:2:" + sessionID + "::NO::P2_MSISDN,P2_CALLID:" +/* CTICommands.phoneNumber */+ 994555902585 + "," + CTICommands.callID /* "994776480368"*/;
        //    MessageBox.Show(upadatedURL);
        //    //string checksessionID = url.Substring(url.Length - Math.Min(16, url.Length));
        //}

        public string getSessionId(string apexURL)
        {
            MessageBox.Show("get session id apex Nar");
            try
            {
                int counter = 0;
                string sessionID = null;
                //http://callsapp.azerfon.az:8080/apex/f?p=118:1:597359879992681::NO
                // MySampleViewPageApex.currentUri.ToString();
                //http://callsapp:8080/apex/f?p=118:2:5900474262395793::NO::P2_MSISDN,P2_CALLID:994555902585,aaddffcc555
                //string newUrl = MySampleViewPageApex.currentUri.ToString();
                string newUrl = apexURL;

                //if (newUrl.Contains("p=118:2:"))
                //{
                int indexofP = newUrl.IndexOf("p=");
                //string sub = url.Substring(indexofP, url.Length);
                for (int i = indexofP; i < newUrl.Length; i++)
                {
                    if (newUrl[i].ToString() == ":")
                    {
                        counter++;
                    }
                    if (counter == 2)
                    {
                        int number;
                        if (true == int.TryParse(newUrl[i].ToString(), out number))
                        {
                            sessionID += newUrl[i].ToString();
                        }
                    }
                }
                //}

                return sessionID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "-1";
            }



            //upadatedURL = "http://callsapp:8080/apex/f?p=118:2:" + sessionID + "::NO::P2_MSISDN,P2_CALLID:" + /*CTICommands.phoneNumber */"994555902585" + "," + CTICommands.callID;
            //MessageBox.Show(upadatedURL);
            //string checksessionID = url.Substring(url.Length - Math.Min(16, url.Length));
        }

        public void getRequest(string sessionID)
        {
            try
            {
                //string postData = "number= " + /*CTICommands.phoneNumber*/ "555902585";
                //System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                //byte[] bytes = encoding.GetBytes(postData);
                string url = "http://10.220.24.7:8080/apex/f?p=122:2:" + sessionID + "::NO::P2_MSISDN,P2_CALLID:" + /*CTICommands.phoneNumber */"994555902585" + "," + CTICommands.callID;
                MessageBox.Show(url);
                //string headers = "Content-Type: application/x-www-form-urlencoded";
                //InternetSetCookie(upadatedURL, "LOGIN_USERNAME_COOKIE", "adilsh");

                foreach (DictionaryEntry cookie in cookiesListAPEXFixed)
                {
                    string key = cookie.Key.ToString();
                    string value = cookie.Value.ToString();
                    MessageBox.Show(key + "-" + value);
                    InternetSetCookie(url, key, value);

                }
                zedApplicationLink.Navigate(url);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void preGetRequest()
        {
            try
            {
                cookiesListAPEXFixed = new OrderedDictionary();
                string url = MySampleViewPageApexFixed.currentUri.ToString();
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
                    cookiesListAPEXFixed.Add(cookie.Name.ToString(), cookie.Value.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
		public IMySampleViewModel Model
		{
			get { return this.DataContext as IMySampleViewModel; }
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
