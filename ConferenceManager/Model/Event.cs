using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model;

public class Event
{
    private static int nextEventId;
    public Event(string title, DateTime date, string venue, string description, string category)
    {
        Id = nextEventId;
        nextEventId++;
        Title = title;
        Date = date;
        Venue = venue;
        Description = description;
        Category = category;
    }
    public int Id { get; init; }
    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
    [JsonPropertyName("date")]
    [Required]
    public DateTime Date { get; set; }
    [JsonPropertyName("venue")]
    [Required]
    public string Venue { get; set; }
    [JsonPropertyName("description")]
    [Required]
    public string Description { get; set; }
    [JsonPropertyName("category")]
    [Required]
    public string Category { get; set; }

}
