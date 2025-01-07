using System.Text.Json.Serialization;

namespace ConferenceManager.Model
{
    public class Event
    {
        public Event(string title, DateTime date, string venue, string description, string category)
        {
            Title = title;
            Date = date;
            Venue = venue;
            Description = description;
            Category = category;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("venue")]
        public string Venue { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }

    }
}
