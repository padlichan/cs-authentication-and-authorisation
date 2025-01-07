using ConferenceManager.Services;
using ConferenceManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("[controller]")]
public class SpeakersController : ControllerBase
{
    private readonly SpeakersService speakersService;
    public SpeakersController(SpeakersService speakersService)
    {
        this.speakersService = speakersService;
    }

    [HttpGet]
    public IActionResult GetSpeakers()
    {
        List<Speaker> speakers = speakersService.GetSpeakers();
        return Ok(speakers);
    }


}
