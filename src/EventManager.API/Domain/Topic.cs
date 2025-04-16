namespace EventManager.API.Domain
{
    public class Topic : DomainBaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public static Topic Create(string name, 
            string? description, 
            bool isActive = true)
        {
            return new Topic
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                IsActive = isActive
            };
        }
    }
}
