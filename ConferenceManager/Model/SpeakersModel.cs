
namespace ConferenceManager.Model;

public class SpeakersModel
{
    private static List<Speaker> speakersData = [];

    static SpeakersModel()
    {
        speakersData = [];
        speakersData.Add(new Speaker("Speaker1", 1));
        speakersData.Add(new Speaker("Speaker2", 1));
        speakersData.Add(new Speaker("Speaker3", 2));
    }

    public List<Speaker> GetSpeakers()
    {
        return speakersData;
    }

    public Speaker AddSpeaker(Speaker speaker)
    {
        speakersData.Add(speaker);
        return speakersData.Last();
    }

    public bool DeleteSpeaker(int speakerId)
    {
        Speaker? speakerToDelete = speakersData.Where(s => s.SpeakerId == speakerId).FirstOrDefault();
        if (speakerToDelete != null)
        {
            speakersData.Remove(speakerToDelete);
            return true;
        }
        return false;
    }

    public Speaker ReplaceSpeaker(int speakerId, SpeakerDto speakerDto, Event @event)
    {
        Speaker speakerToUpdate = speakersData.Where(s => s.SpeakerId == speakerId).First();
        int index = speakersData.FindIndex(s => s.SpeakerId == speakerId);
        speakersData[index] = new Speaker(speakerDto.Name, speakerDto.EventId);
        speakersData[index].Event = @event;
        return speakersData[index];      
    }
}
