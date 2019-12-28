using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationServer.DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// ReSharper disable InconsistentNaming
namespace AuthenticationServer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _appSettings;
        
        public AuthService(UserManager<ApplicationUser> userManager, IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public async Task<string> LoginWindows(string userName, string domainSID)
        {
            var existingUser = _userRepository.GetUserByDomainSID(domainSID);

            if (existingUser == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = userName,
                    DomainSID = domainSID,
                };

                var result = await _userManager.CreateAsync(newUser, Path.GetRandomFileName());

                if (!result.Succeeded)
                {
                    var errorMessages = string.Join(", ", result.Errors.Select(x => x.Description));

                    throw new ArgumentException(errorMessages);
                }

                existingUser = newUser;
            }

            return GenerateToken(existingUser.Id);
        }

        private string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}