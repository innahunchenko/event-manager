namespace EventManager.API.Requests
{
    public class TopicRequest : IRequest
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}

