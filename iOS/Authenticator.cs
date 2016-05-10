using System;
using Xamarin.Forms;
using LoginScreen.iOS;
using Xamarin.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UIKit;

[assembly: Dependency(typeof(Authenticator))]

namespace LoginScreen.iOS
{
	public class Authenticator : IAuthenticator
	{
		public Authenticator()
		{
		}

		public async Task<AuthenticationResult> Authenticate(string authority, string resourceId, string clientId, Uri redirectUri)
		{
			var authContext = new AuthenticationContext(authority);

			if (authContext.TokenCache.ReadItems().Any())
			{
				authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
			}

			var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while(controller.PresentedViewController != null)
			{
				controller = controller.PresentedViewController;
			}

			var paramaters = new PlatformParameters(controller);

			var authResult = await authContext.AcquireTokenAsync(resourceId, clientId, redirectUri, paramaters);
			return authResult;
		}

		public async Task<bool> DeAuthenticate(string authority)
		{
			try
			{
				var authContext = new AuthenticationContext(authority);
				await Task.Factory.StartNew(() =>
				{
					authContext.TokenCache.Clear();
				});
			}
			catch (Exception ex)
			{

				return false;
			}
			return true;
		}
	}
}

