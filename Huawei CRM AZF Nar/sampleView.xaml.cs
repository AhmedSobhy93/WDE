using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System;
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
using System.Windows.Shapes;

using System.Windows.Navigation;

namespace Genesyslab.Desktop.Modules.ExtensionSample.Huawei_CRM_AZF_Nar
{
    /// <summary>
    /// Interaction logic for sampleView.xaml
    /// </summary>
    public partial class sampleView : UserControl, IextensionSampleView
    {
        public sampleView(IextensionSampleViewModel mySampleViewModel)
        {
            this.Model = mySampleViewModel;

            InitializeComponent();
           // targetStringToCompare = zedApplicationLink.ToString();
            //zedApplicationLink.Navigating += myBrowser_Navigating;
            HideScriptErrors(zedApplicationLink, true);
           //var link = new UriBuilder("https://www.facebook.com/").Uri;
           // zedApplicationLink.Source = link;
            Width = Double.NaN;
            Height = Double.NaN;

            MinSize = new MSize() { Width = 400.0, Height = 400.0 };
        }


        #region IMySampleView Members

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public IextensionSampleViewModel Model
        {
            get { return this.DataContext as IextensionSampleViewModel; }
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
