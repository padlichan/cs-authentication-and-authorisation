using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealthStatus()
    {
        string response = "Server responding.";
        return Ok(response);
    }
}
