using System.Threading.Tasks;

namespace AuthenticationServer.Services
{
    public interface IAuthService
    {
        Task<string> LoginWindows(string userName, string domainSID);
    }
}