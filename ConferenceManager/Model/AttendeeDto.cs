using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model
{
    public class AttendeeDto
    {
        [JsonPropertyName("name")]
        [Required]
        public required string Name { get; set; }

        [JsonPropertyName("eventId")]
        [Required]
        public int EventId { get; set; }
    }
}
