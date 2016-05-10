using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginScreen
{
	public partial class LoginScreen : ContentPage
	{
		public LoginScreen()
		{
			InitializeComponent();

			loginBtn.Clicked += OnLoginClicked;
		}

		async void OnLoginClicked(object sender, EventArgs e)
		{

			var auth = new AuthServices();

			if(	await auth.AuthenticateAsync() )
			{
				failureTxt.IsVisible = false;
				await Navigation.PushAsync(new DataDisplay());
			}
			else
			{
				failureTxt.IsVisible = true;
			}

		}


	}
}

