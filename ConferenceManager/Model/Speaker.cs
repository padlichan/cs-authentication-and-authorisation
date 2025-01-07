using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model;

public class Speaker
{
    public Speaker(int userId, string name, int eventId)
    {
        UserId = userId; 
        Name = name;
        EventId = eventId;
    }

    [Required]
    [JsonPropertyName("id")]
    int UserId { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [Required]
    [JsonPropertyName("eventId")]
    public int EventId  { get; set; }
    public Event Event { get; set; }
}
