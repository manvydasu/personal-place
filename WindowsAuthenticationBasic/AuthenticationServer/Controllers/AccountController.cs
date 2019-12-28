using System.Security.Principal;
using System.Threading.Tasks;
using AuthenticationServer.Models;
using AuthenticationServer.Services;
using AuthenticationServer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace AuthenticationServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login-windows")]
        [HttpGet]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            if (HttpContext.User.Identity.IsAuthenticated &&
                HttpContext.User.Identity is WindowsIdentity windowsIdentity)
            {
                var token = await _authService.LoginWindows(
                    windowsIdentity.GetNameWithoutDomain(),
                    windowsIdentity.User.AccountDomainSid.Value
                );

                return Ok(token);
            }

            return Challenge(HttpSysDefaults.AuthenticationScheme);
        }
    }
}