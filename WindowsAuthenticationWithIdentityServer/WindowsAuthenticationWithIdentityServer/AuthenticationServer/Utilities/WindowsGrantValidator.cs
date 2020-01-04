using System.Security.Principal;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;

namespace AuthenticationServer.Utilities
{
    public class WindowsGrantValidator : IExtensionGrantValidator
    {
        public string GrantType => Constants.WindowsGrantType;
        
        private readonly HttpContext _httpContext;
        
        public WindowsGrantValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext =  httpContextAccessor.HttpContext;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            
            var result = await _httpContext.AuthenticateAsync(HttpSysDefaults.AuthenticationScheme);

            if (result?.Principal is WindowsPrincipal wp)
            {
                context.Result = new GrantValidationResult(wp.Identity.Name, GrantType, wp.Claims);
            }
            else
            {
                await _httpContext.ChallengeAsync(HttpSysDefaults.AuthenticationScheme);
                context.Result = new GrantValidationResult { IsError = false, Error = null, Subject = null };
            }
        }
    }
}