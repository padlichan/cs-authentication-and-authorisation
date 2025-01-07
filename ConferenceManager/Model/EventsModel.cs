using System.Text.Json;

namespace ConferenceManager.Model
{
    public class EventsModel
    {
        public Event? GetEventById(int id)
        {
            var events = GetEvents();
            var eventById = events.Where(e => e.Id == id).FirstOrDefault();
            return eventById;
        }

        public List<Event> GetEvents()
        {
            var events = ReadData();
            if(events == null) return [];
            return events;
        }

        private List<Event>? ReadData()
        {
            string jsonString = File.ReadAllText("Resources/EventData.json");
            List<Event>? events = JsonSerializer.Deserialize<List<Event>>(jsonString);
            return events;
        }
    }
}
