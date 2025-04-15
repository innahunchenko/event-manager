namespace EventManager.API.Database.Models
{
    public class TopicEntity : DbEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
