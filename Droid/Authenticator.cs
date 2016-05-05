using System;
using System.Threading.Tasks;
using Android.App;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Linq;
using Xamarin.Forms;
using LoginScreen.Droid;

[assembly: Dependency(typeof(Authenticator))]
namespace LoginScreen.Droid
{
	public class Authenticator : IAuthenticator
	{
		public Authenticator()
		{
		}

		public async Task<AuthenticationResult> Authenticate(string authority, string resourceId, string clientId, Uri redirectUri)
		{
			var authContext = new AuthenticationContext(authority);

			/*
			if(authContext.TokenCache.ReadItems().Any())
			{
				authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
			}
			*/

			var parameters = new PlatformParameters((Activity)Forms.Context);

			var authResult = await authContext.AcquireTokenAsync(resourceId, clientId, redirectUri, parameters);
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

