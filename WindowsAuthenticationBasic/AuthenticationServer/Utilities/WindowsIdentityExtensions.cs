using System.Linq;
using System.Security.Principal;

namespace AuthenticationServer.Utilities
{
    public static class WindowsIdentityExtensions
    {
        public static string GetNameWithoutDomain(this WindowsIdentity windowsIdentity)
        {
            return windowsIdentity.Name.Split('\\').Last();
        }
    }
}