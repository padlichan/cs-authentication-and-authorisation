using System.Text.Json;

namespace ConferenceManager.Model;

public class EventsModel
{
    private static List<Event> eventsData;
    static EventsModel()
    {
        eventsData = ReadData();
    }

    public Event? GetEventById(int id)
    {
        var events = GetEvents();
        var eventById = events.Where(e => e.Id == id).FirstOrDefault();
        return eventById;
    }

    public List<Event> GetEvents()
    {
        return eventsData;
    }

    public Event AddEvent(Event eventToAdd)
    {
        eventsData.Add(eventToAdd);
        return eventsData.Last();
    }

    private static List<Event> ReadData()
    {
        string jsonString = File.ReadAllText("Resources/EventData.json");
        List<Event>? events = JsonSerializer.Deserialize<List<Event>>(jsonString);
        if (events != null) return events;
        return [];
    }
}
