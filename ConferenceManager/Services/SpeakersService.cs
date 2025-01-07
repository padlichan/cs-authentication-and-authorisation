using ConferenceManager.Model;

namespace ConferenceManager.Services;

public class SpeakersService
{
    private SpeakersModel speakersModel;
    public SpeakersService(SpeakersModel speakersModel)
    {
        this.speakersModel = speakersModel;
    }

    public List<Speaker> GetSpeakers()
    {
        return speakersModel.GetSpeakers();
    }
}
