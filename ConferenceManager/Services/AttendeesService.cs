using ConferenceManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Services;

public class AttendeesService
{
    private AttendeesModel attendeesModel;
    private EventsService eventsService;

    public const string ALREADY_EXISTS_ERROR_MESSAGE = "Attendee already exists.";
    public const string NOT_FOUND_ERROR_MESSAGE = "Attendee not found.";
    public const string FORBIDDEN_ERROR_MESSAGE = "Access denied.";
    public const string INVALID_EVENT_ERROR_MESSAGE = "Invalid event";

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
            if (attendeesModel.GetAttendees().Any(a => a.UserId == userId && a.EventId == attendeeDto.EventId)) return Result<Attendee>.Error(ALREADY_EXISTS_ERROR_MESSAGE);
            Attendee attendee = new Attendee(userId, attendeeDto.Name, attendeeDto.EventId);
            Event @event = eventsService.GetEventById(attendeeDto.EventId)!;
            var addedAttendee = attendeesModel.AddAttendee(attendee, @event);
            return Result<Attendee>.Success(addedAttendee);
        }
        return Result<Attendee>.Error(INVALID_EVENT_ERROR_MESSAGE);
    }

    public Result<Attendee> GetAttendeeById(int userId, int attendeeId)
    {
        Attendee? attendee = attendeesModel.GetAttendeesById(attendeeId);
        if(attendee == null) return Result<Attendee>.Error(NOT_FOUND_ERROR_MESSAGE);
        if (attendee.UserId != userId) return Result<Attendee>.Error(FORBIDDEN_ERROR_MESSAGE);
        return new Result<Attendee>(true, attendee);
    }
}
