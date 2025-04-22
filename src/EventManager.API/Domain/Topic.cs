namespace EventManager.API.Domain
{
    public class Topic : IEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
