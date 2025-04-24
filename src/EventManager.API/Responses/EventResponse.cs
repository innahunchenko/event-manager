namespace EventManager.API.Responses
{
    public class EventResponse
    {
        public string Id { get; set; } = string.Empty;
        public string SpeakerFirstName { get; set; } = string.Empty;
        public string SpeakerLastName { get; set; } = string.Empty;
        public string SpeakerPosition { get; set; } = string.Empty;
        public string SpeakerCompany { get; set; } = string.Empty;
        public string TopicName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
