using ConferenceManager.Model;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ConferenceManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendeesController : ControllerBase
{

    private AttendeesService attendeesService;
    public AttendeesController(AttendeesService attendeesService)
    {
        this.attendeesService = attendeesService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAttendees()
    {
        List<Attendee> attendees = attendeesService.GetAttendees();
        return Ok(attendees);
    }

    [Route("{attendeeId}")]
    [HttpGet]
    public IActionResult GetAttendeesById(int attendeeId)
    {
        int userId = ControllerHelper.GetUserIdFromContext(HttpContext);
        if (userId == int.MinValue) return BadRequest("Invalid userId");
        Result<Attendee> result = attendeesService.GetAttendeeById(userId, attendeeId);
        if (result.IsSuccess) return Ok(result.Data);
        else if (result.ErrorMessage == "Access denied") return Unauthorized(result.ErrorMessage);
        else return BadRequest(result.ErrorMessage);
    }


    [HttpPost]
    [Authorize]
    public IActionResult PostAttendee(AttendeeDto attendeeDto)
    {
        int userId = ControllerHelper.GetUserIdFromContext(HttpContext);
        if (userId == int.MinValue) return BadRequest("Invalid userId");
        Result<Attendee> attendeeResult = attendeesService.AddAttendee(attendeeDto, userId);
        if (attendeeResult.IsSuccess) return Ok(attendeeResult.Data);
        return BadRequest(attendeeResult.ErrorMessage);
    }
}
