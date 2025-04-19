namespace EventManager.API.Requests
{
    public class EventRequest : IRequest
    {
        public string Id { get; set; } = "";
        public string SpeakerId { get; set; } = "";
        public string TopicId { get; set; } = "";
        public DateTime DateTime { get; set; }
    }
}
