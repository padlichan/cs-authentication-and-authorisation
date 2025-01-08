using ConferenceManager.Services;
using ConferenceManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult PostSpeaker(SpeakerDto speakerDto)
    {
        Result<Speaker> result = speakersService.AddSpeaker(speakerDto);
        if(result.IsSuccess) return Ok(result.Data);
        return BadRequest(result.ErrorMessage);
    }

    [HttpDelete]
    [Route("{speakerId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteSpeaker(int speakerId)
    {
        if (speakersService.DeleteSpeaker(speakerId)) return NoContent();
        else return NotFound();
    }

    [HttpPut]
    [Route("{speakerId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult PutSpeaker(SpeakerDto speakerDto, int speakerId)
    {
        Result<Speaker> updatedSpeakerResult = speakersService.UpdateSpeaker(speakerDto, speakerId);
        if(updatedSpeakerResult.IsSuccess) return Ok(updatedSpeakerResult.Data);
        if (updatedSpeakerResult.ErrorMessage == SpeakersService.NOT_FOUND_ERROR_MESSAGE) return NotFound(updatedSpeakerResult.ErrorMessage);
        return BadRequest(updatedSpeakerResult.ErrorMessage);
    }
}
