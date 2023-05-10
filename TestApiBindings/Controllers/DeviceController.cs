using Microsoft.AspNetCore.Mvc;
using TestApiBindings.Models;

namespace TestApiBindings.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(Device device)
    {
        return Ok();
    }
}
