using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;

namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample
{
	/// <summary>
	/// The behabior of the MySampleView class
	/// </summary>
	public class MySampleViewModel : IMySampleViewModel, INotifyPropertyChanged
	{
		// Field variables
		string header = "My Sample Header";
		TimeSpan counter = TimeSpan.Zero;
		ICase @case;

		/// <summary>
		/// Initializes a new instance of the <see cref="MySampleViewModel"/> class.
		/// </summary>
		/// <param name="view">The view.</param>
		public MySampleViewModel()
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
		/// Gets or sets the counter.
		/// </summary>
		/// <value>The counter.</value>
		public TimeSpan Counter
		{
			get { return counter; }
			set { if (counter != value) { counter = value; OnPropertyChanged("Counter"); } }
		}

		/// <summary>
		/// Gets or sets the case.
		/// </summary>
		/// <value>The case.</value>
		public ICase Case
		{
			get { return @case; }
			set { if (@case != value) { @case = value; OnPropertyChanged("Case"); } }
		}

		/// <summary>
		/// Reset the counter.
		/// </summary>
		public void ResetCounter()
		{
			Counter = TimeSpan.Zero;
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
