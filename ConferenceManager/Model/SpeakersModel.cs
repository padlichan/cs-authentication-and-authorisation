namespace ConferenceManager.Model;

public class SpeakersModel
{
    private List<Speaker> speakersData;

    public SpeakersModel()
    {
        speakersData = [];
        speakersData.Add(new Speaker(1, "Speaker1", 1));
        speakersData.Add(new Speaker(2, "Speaker2", 1));
        speakersData.Add(new Speaker(3, "Speaker3", 2));
    }

    public List<Speaker> GetSpeakers()
    {
        return speakersData;
    }
}
