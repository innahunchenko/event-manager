namespace EventManager.API.Database.Models
{
    public class EventEntity : DbBaseEntity
    {
        public Guid SpeakerId { get; set; } = default!;
        public Guid TopicId { get; set; } = default!;
        public DateTime DateTime { get; set; } = default!;
        public string Agenda { get; set; } = default!;
        public bool IsSpeakerActive { get; set; }
        public ICollection<UserEventEntity>? UserEvents { get; set; } = new List<UserEventEntity>();
    }
}
