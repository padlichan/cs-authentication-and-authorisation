namespace ConferenceManager.Services;
using ConferenceManager.Model;

public class EventsService
{
    private EventsModel eventModel;

    public EventsService(EventsModel eventModel)
    { 
        this.eventModel = eventModel; 
    }
    public Event? GetEventById(int id)
    {
        return eventModel.GetEventById(id);
    }

    public List<Event> GetEvents()
    {
        return eventModel.GetEvents();
    }

    public Event AddEvent(Event eventToAdd)
    {
        return eventModel.AddEvent(eventToAdd);
    }
}
