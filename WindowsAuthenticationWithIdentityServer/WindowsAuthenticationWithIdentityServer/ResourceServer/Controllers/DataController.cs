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
                new { id = 1, value = "Value1"},
                new { id = 2, value = "Value2"},
                new { id = 3, value = "Value3"},
                new { id = 4, value = "Value4"},
                new { id = 5, value = "Value5"},
            };

            return Ok(data);
        }
    }
}