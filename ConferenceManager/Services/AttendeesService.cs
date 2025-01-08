using ConferenceManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Services;

public class AttendeesService
{
    private AttendeesModel attendeesModel;
    private EventsService eventsService;

    public AttendeesService(AttendeesModel attendeesModel, EventsService eventsService)
    {
        this.attendeesModel = attendeesModel;
        this.eventsService = eventsService;
    }

    public List<Attendee> GetAttendees()
    {
        return attendeesModel.GetAttendees();
    }

    public Result<Attendee> AddAttendee(AttendeeDto attendeeDto, int userId)
    {
        if (eventsService.IsValidEventId(attendeeDto.EventId))
        {
            if (attendeesModel.GetAttendees().Any(a => a.UserId == userId && a.EventId == attendeeDto.EventId)) return Result<Attendee>.Error("Attendee already exists.");
            Attendee attendee = new Attendee(userId, attendeeDto.Name, attendeeDto.EventId);
            Event @event = eventsService.GetEventById(attendeeDto.EventId)!;
            var addedAttendee = attendeesModel.AddAttendee(attendee, @event);
            return Result<Attendee>.Success(addedAttendee);
        }
        return Result<Attendee>.Error("Event not found.");
    }

    public Result<Attendee> GetAttendeeById(int userId, int attendeeId)
    {
        Attendee? attendee = attendeesModel.GetAttendeesById(attendeeId);
        if(attendee == null) return Result<Attendee>.Error("Not Found");
        if (attendee.UserId != userId) return Result<Attendee>.Error("Access denied");
        return new Result<Attendee>(true, attendee);
    }
}
