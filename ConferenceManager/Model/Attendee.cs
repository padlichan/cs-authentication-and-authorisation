using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model;

public class Attendee
{
    private static int NextAttendeeId = 1;
    public Attendee(int userId, string name, int eventId)
    {
        UserId = userId;
        Name = name;
        EventId = eventId;
        Event = null;
        AttendeeId = NextAttendeeId;
        NextAttendeeId++;
    }
    public int AttendeeId { get; init; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    [JsonPropertyName("name")]
    [Required] 
    public string Name { get; set; }
    [JsonPropertyName("eventId")]
    [Required] 
    public int EventId { get; set; }
    public Event? Event { get; set; }
}
