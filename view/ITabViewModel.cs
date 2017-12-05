using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;
using System.ComponentModel;

namespace Genesyslab.Desktop.Modules.ExtensionSample.views
{
    public class ITabViewModel : IITabViewModel, INotifyPropertyChanged
    {
        ICase @case;
        public ICase Case
        {
            get { return @case; }
            set { if (@case != value) { @case = value; OnPropertyChanged("Case"); } }
        }

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
