using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace OneTokenPlease.AuthServices
{
  public class AzureActiveDirectoryAuthService : IAuthService
  {
    public async Task<string> Auth(AuthServerCreds authServerCreds) {
      var authContext = new AuthenticationContext(authServerCreds.Authority);
      var clientCreds = new ClientCredential(authServerCreds.ClientId, authServerCreds.AppKey);

      AuthenticationResult result = 
        await authContext.AcquireTokenAsync(authServerCreds.Resource, clientCreds);
      return $"Bearer {result.AccessToken}";
    }
  }
}
