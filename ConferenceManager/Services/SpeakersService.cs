using ConferenceManager.Model;

namespace ConferenceManager.Services;

public class SpeakersService
{
    private SpeakersModel speakersModel;
    private EventsService eventsService;
    public const string NOT_FOUND_ERROR_MESSAGE = "Speaker not found.";
    public const string INVALID_EVENTID_ERROR_MESSAGE = "Invalid eventId."; 
    public SpeakersService(SpeakersModel speakersModel, EventsService eventsService)
    {
        this.speakersModel = speakersModel;
        this.eventsService = eventsService;
    }

    public List<Speaker> GetSpeakers()
    {
        return speakersModel.GetSpeakers();
    }

    public Result<Speaker> AddSpeaker(SpeakerDto speakerDto)
    {
        bool isValidEventId = eventsService.IsValidEventId(speakerDto.EventId);
        if (isValidEventId)
        {
            Speaker speaker = new Speaker(speakerDto.Name, speakerDto.EventId);
            speaker.Event = eventsService.GetEventById(speaker.EventId);
            Speaker addedSpeaker = speakersModel.AddSpeaker(speaker);
            return Result<Speaker>.Success(addedSpeaker);
        }
        return Result<Speaker>.Error(INVALID_EVENTID_ERROR_MESSAGE);
    }

    internal bool DeleteSpeaker(int speakerId)
    {
        return speakersModel.DeleteSpeaker(speakerId);
    }

    internal Result<Speaker> UpdateSpeaker(SpeakerDto speakerDto, int speakerId)
    {
        Speaker? speakerToUpdate = speakersModel.GetSpeakers().Where(s => s.SpeakerId == speakerId).FirstOrDefault();
        if (speakerToUpdate != null)
        {
            if (eventsService.IsValidEventId(speakerDto.EventId))
            {
                Event @event = eventsService.GetEventById(speakerDto.EventId)!;
                Speaker updatedSpeaker = speakersModel.ReplaceSpeaker(speakerId, speakerDto, @event);
                return Result<Speaker>.Success(updatedSpeaker);
            }
            return Result<Speaker>.Error(INVALID_EVENTID_ERROR_MESSAGE);

        }
        return Result<Speaker>.Error(NOT_FOUND_ERROR_MESSAGE);
    }
}
