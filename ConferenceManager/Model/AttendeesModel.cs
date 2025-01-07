namespace ConferenceManager.Model;
public class AttendeesModel
{
    private static List<Attendee> attendees = [];

    public List<Attendee> GetAttendees()
    {
        return attendees;
    }

    public Attendee AddAttendee(Attendee attendee, Event @event)
    {
        //Add attendee to db
        //Return added attendee
        attendee.Event = @event;
        attendees.Add(attendee);
        return attendees.Last();
    }
}
