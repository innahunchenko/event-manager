namespace EventManager.API.Database.Models
{
    public class UserEventEntity : DbBaseEntity
    {
        public Guid UserId { get; set; } = default!;
        public Guid EventId { get; set; } = default!;
    }
}
