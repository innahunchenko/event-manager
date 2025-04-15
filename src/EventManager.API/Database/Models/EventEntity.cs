namespace EventManager.API.Database.Models
{
    public class EventEntity : DbEntity
    {
        public string SpeakerId { get; set; } = default!;
        public string TopicId { get; set; } = default!;
        public DateTime DateTime { get; set; } = default!;
        public string Agenda { get; set; } = default!;
    }
}
