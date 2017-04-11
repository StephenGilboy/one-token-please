using System.Threading.Tasks;

namespace OneTokenPlease.AuthServices {
	public interface IAuthService {
    Task<string> Auth(AuthServerCreds authServerCreds);
	}
}
