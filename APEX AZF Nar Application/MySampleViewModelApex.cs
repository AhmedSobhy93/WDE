using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.APEX_AZF_Nar_Application
{
    public class MySampleViewModelApex : IMyExtensionSampleViewModelApex, INotifyPropertyChanged
    {

        // Field variables
        string header = "Apex Azf Application";
        ObservableCollection<IMyListItem> myCollection;
        /// <summary>
        /// Initializes a new instance of the <see cref="MySampleViewModel"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public MySampleViewModelApex()
        {

        }

        #region IMySamplePresentationModel Members

        /// <summary>
        /// Gets or sets the header to set in the parent view.
        /// </summary>
        /// <value>The header.</value>
        public string Header
        {
            get { return header; }
            set { if (header != value) { header = value; OnPropertyChanged("Header"); } }
        }


        /// <summary>
        /// Gets or sets my collection.
        /// </summary>
        /// <value>
        /// My collection.
        /// </value>
        public ObservableCollection<IMyListItem> MyCollection
        {
            get { return myCollection; }
            set { if (myCollection != value) { myCollection = value; OnPropertyChanged("MyCollection"); } }
        }


        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
