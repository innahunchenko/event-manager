namespace EventManager.API.Database.Models
{
    public class TopicEntity : DbBaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
