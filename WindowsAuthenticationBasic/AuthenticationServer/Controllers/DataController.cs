using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        public IActionResult Get()
        {
            var data = new []
            {
                1,
                2,
                3,
                5,
                8
            };

            return Ok(data);
        }
    }
}