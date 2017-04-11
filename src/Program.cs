using System;
using Microsoft.Extensions.CommandLineUtils;

namespace OneTokenPlease
{
  using AuthServices;

  class Program
  {
    // Parms:
    // -a|--authority authority (https://login.microsoftonline.com/yourcompany.onmicrosoft.com)
    // -c|--clientId clientId (GUID if aad)
    // -k|--key appKey (appKey given in aad portal)
    // -r|--resource resource (https://yourcompany.onmicrosoft.com/ApplicationName)
    // -s|--service aad (azure active directory)
    static CommandOption service;
    static CommandOption clientId;
    static CommandOption appKey;
    static CommandOption resource;
    static CommandOption authority;

		static void Main(string[] args)
    {
      var cli = new CommandLineApplication(throwOnUnexpectedArg: false);
      service = cli.Option("-s |--service <service>",
                "Service you are authenticating against. aad if Azure Active Directory, which is the default.",
                 CommandOptionType.SingleValue);
      clientId = cli.Option("-c |--clientId <clientId>",
                "The client ID, it is a GUID if using aad",
                 CommandOptionType.SingleValue);
      appKey = cli.Option("-k |--key <applicationKey>",
                "The application key. For aad this will be the Application Key created in the portal",
                 CommandOptionType.SingleValue);
      resource = cli.Option("-r |--resource <resource>",
                "If aad (https://yourcompany.onmicrosoft.com/ApplicationName",
                 CommandOptionType.SingleValue);
      authority = cli.Option("-a |--authority <authority>",
                "If aad (https://login.microsoftonline.com/yourcompany.onmicrosoft.com",
                 CommandOptionType.SingleValue);

      cli.OnExecute(() => Execute());

      cli.Execute(args);
    }

    static int Execute() {
      IAuthService authService;

      // Get the Auth Service 
      var authServiceResult = GetAuthService();
      // Item1 == hasError
      if (authServiceResult.Item1 == true) {
        return 0;
      } else {
        authService = authServiceResult.Item2;
      }

      var authCreds = new AuthServerCreds(authority.Value(), resource.Value(), clientId.Value(), appKey.Value());
      var token = authService.Auth(authCreds);
      token.Wait();
      Console.WriteLine(token.Result);
      return 0;
    }

    /// <summary>
    /// Gets the auth service.
    /// </summary>
    /// <returns>(false, authService) if no error. (true, null) if error</returns>
    static Tuple<bool, IAuthService> GetAuthService() {
      IAuthService authService = null;
      bool hasError = false;
			// Check the Service 
			if (service.HasValue())
			{
				switch (service.Value().ToLower())
				{
					case "aad":
						authService = new AzureActiveDirectoryAuthService();
						break;

					default:
						{
							Console.WriteLine($"{service.Value()} is not a known service");
              hasError = true;
						}
						break;
				}
			}
			else
			{
        authService = new AzureActiveDirectoryAuthService();
			}
      return new Tuple<bool, IAuthService>(hasError, authService);
    }
  }
}
