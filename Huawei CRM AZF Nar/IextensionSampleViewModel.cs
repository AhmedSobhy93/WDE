﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesyslab.Desktop.Modules.ExtensionSample.Huawei_CRM_AZF_Nar
{
    public interface IMyListItem : INotifyPropertyChanged
    {

    }
    public interface IextensionSampleViewModel
    {
        /// <summary>
		/// Gets or sets the header to set in the parent view.
		/// </summary>
		/// <value>The header.</value>
		string Header { get; set; }

		/// <summary>
		/// Gets or sets my collection.
		/// </summary>
		/// <value>
		/// My collection.
		/// </value>
		ObservableCollection<IMyListItem> MyCollection { get; set; }
    }
}
