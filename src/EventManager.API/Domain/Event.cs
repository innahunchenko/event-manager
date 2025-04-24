namespace EventManager.API.Domain
{
    public class Event : IEntity
    {
        public DateTime DateTime { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? SpeakerId { get; set; }
        public Topic? Topic { get; set; } = new();
        public User? Speaker { get; set; } = new();
    }
}
