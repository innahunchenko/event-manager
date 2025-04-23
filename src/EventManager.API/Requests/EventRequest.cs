namespace EventManager.API.Requests
{
    public class EventRequest
    {
        public string SpeakerId { get; set; } = string.Empty;
        public string TopicId { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
