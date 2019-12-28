using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string DomainSID { get; set; }
    }
}