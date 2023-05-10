using Microsoft.AspNetCore.Mvc;
using TestApiBindings.Models;

namespace TestApiBindings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok();
        }
    }
}
