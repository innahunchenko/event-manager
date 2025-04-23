namespace EventManager.API.Database.Models
{
    public class EventEntity : DbBaseEntity
    {
        public Guid? SpeakerId { get; set; }
        public UserEntity? Speaker { get; set; }
        public TopicEntity? Topic { get; set; }
        public Guid? TopicId { get; set; }
        public DateTime DateTime { get; set; } = default!;
        public bool IsSpeakerActive { get; set; }
        public ICollection<UserEventEntity>? UserEvents { get; set; } = new List<UserEventEntity>();
    }
}
