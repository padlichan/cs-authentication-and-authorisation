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

    public Attendee? AddAttendee(AttendeeDto attendeeDto, int userId)
    {
        if (eventsService.IsValidEventId(attendeeDto.EventId))
        {
            if (attendeesModel.GetAttendees().Any(a => a.UserId == userId && a.EventId == attendeeDto.EventId)) return null;
            Attendee attendee = new Attendee(userId, attendeeDto.Name, attendeeDto.EventId);
            Event @event = eventsService.GetEventById(attendeeDto.EventId)!;
            var addedAttendee = attendeesModel.AddAttendee(attendee, @event);
            return addedAttendee;
        }
        return null;
    }
}
