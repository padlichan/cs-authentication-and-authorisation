using ConferenceManager.Model;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
    public IActionResult GetAttendees()
    {
        List<Attendee> attendees = attendeesService.GetAttendees();
        return Ok(attendees);
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostAttendee(AttendeeDto attendeeDto)
    {
        string? userIdString = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (userIdString == null) return BadRequest("User id cannot be null.");
        int userId = int.Parse(userIdString);
        Attendee? addedAttendee = attendeesService.AddAttendee(attendeeDto, userId);
        if (addedAttendee != null) return Ok(addedAttendee);
        return BadRequest("Invalid eventId.");
    }
}
