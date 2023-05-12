using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApiBindings.Models;

namespace TestApiBindings.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    [HttpPost("{kind}")]
    public IActionResult Post(string kind, [FromBody] Device device)
    {
        return Ok($"Received object of type {device.GetType()}: {JsonConvert.SerializeObject(device)}");
    }
}
