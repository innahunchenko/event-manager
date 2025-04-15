namespace EventManager.API.Database.Models
{
    public class UserEventEntity : DbEntity
    {
        public string UserId { get; set; } = default!;
        public string EventId { get; set; } = default!;
    }
}
