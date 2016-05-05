using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace LoginScreen
{
	public class AuthServices
	{
		private string ClientId = "51d0ca81-8d68-4517-abe4-be81629662c5";
		private string commonAuthority = "https://login.windows.net/loginappexample.onmicrosoft.com";
		//Redirect URI
		private static Uri RedirectURI = new Uri("http://xam-demo-redirect");


		//Graph URI if you've given permission to Azure Active Directory
		private static string graphResourceUri = "https://graph.windows.net";


		//AuthenticationResult will hold the result after authentication completes
		AuthenticationResult authResult = null;
		readonly IAuthenticator Authenticator;


		public AuthServices()
		{
			Authenticator = DependencyService.Get<IAuthenticator>();
		}

		public async Task<bool> AuthenticateAsync()
		{
			bool success = false;
			try{
				authResult = await Authenticator.Authenticate(commonAuthority, graphResourceUri, ClientId, RedirectURI);
				success = true;
			}
			catch( Exception ex)
			{
				//Do Something
			}

			return success;
		}

		public async Task<bool> LogoutAsync()
		{

			await Task.Factory.StartNew(async () =>
				{
				var success = await Authenticator.DeAuthenticate(commonAuthority);
					if (!success)
					{
						throw new Exception("Failed to DeAuthenticate!");
					}
					//_AuthenticationResult = null;
				});
			return true;
		}

	}
}

