namespace OneTokenPlease.AuthServices
{
  public class AuthServerCreds
  {
    public AuthServerCreds(string authority, string resource, string clientId, string appKey) {
      ClientId = clientId;
      Authority = authority;
      AppKey = appKey;
      Resource = resource;
    }
    
    public string ClientId { get; private set; }
    public string Authority { get; private set; }
    public string AppKey { get; private set; }
    public string Resource { get; private set; }
  }
}
