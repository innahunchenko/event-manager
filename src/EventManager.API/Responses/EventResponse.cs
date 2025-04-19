namespace EventManager.API.Responses
{
    public record EventResponse(
        string SpeakerFirstName,
        string SpeakerLastName,
        string SpeakerPosition,
        string SpeakerCompany,
        string TopicName,
        DateTime DateTime);
}
