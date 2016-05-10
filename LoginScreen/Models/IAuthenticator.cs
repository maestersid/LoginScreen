using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace LoginScreen
{
	public interface IAuthenticator
	{
		Task<AuthenticationResult> Authenticate(string authority, string resourceId, string clientId, Uri redirectUri);
		Task<bool> DeAuthenticate(string authority);

	}
}

