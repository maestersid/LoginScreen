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
			//var username = usernameTxt.Text;
			//var pwd = passwordTxt.Text;

			//if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
			//{
			//	DisplayAlert("Invalid Credentials", $"Username and password cannot be empty!", "OK");
			//	return;
			//}


			//TODO
			var auth = new AuthServices();

			if(	await auth.AuthenticateAsync() )
			{
				failureTxt.IsVisible = false;
				await Navigation.PushAsync(new ContentPage
				{
					Content = new Label
					{
						Text = "Login Successful!"
					}

					});
			}
			else
			{
				failureTxt.IsVisible = true;
			}

		}


	}
}

