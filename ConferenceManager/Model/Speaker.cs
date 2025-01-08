using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model;

public class Speaker
{
    private static int nextSpeakerId = 1;
    public Speaker(string name, int eventId)
    {
        SpeakerId = nextSpeakerId;
        nextSpeakerId++; 
        Name = name;
        EventId = eventId;
        Event = null;
    }

    public int SpeakerId { get; init; }
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [Required]
    [JsonPropertyName("eventId")]
    public int EventId  { get; set; }
    public Event? Event { get; set; }
}
