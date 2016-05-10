using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginScreen
{
	public partial class DataDisplay : ContentPage
	{
		DataViewModel vm;

		public DataDisplay()
		{
			InitializeComponent();
			vm = new DataViewModel();
			BindingContext = vm;

			ButtonGet.Clicked += async (sender, e) =>
			{
				try
				{
					ButtonGet.IsEnabled = false;
					await vm.GetDataAsync();
					ButtonGet.IsEnabled = true;
				}
				catch (Exception ex)
				{
					DisplayAlert("Error", $"Unable to receive data: {ex.Message}", "OK");
				}
			};
		}
	}
}

