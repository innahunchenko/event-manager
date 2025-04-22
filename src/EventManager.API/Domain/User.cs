using EventManager.API.Database.Models;

namespace EventManager.API.Domain
{
    public class User : IEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Company { get; set; } = default!;
        public float YearsOfExperience { get; set; }
        public UserRole Role { get; set; }

        private readonly List<Guid> eventIds = new();
        public IReadOnlyCollection<Guid>? EventIds => eventIds;

        public void AddEventIds(IEnumerable<Guid> ids)
        {
            eventIds.Clear();
            eventIds.AddRange(ids);
        }
    }
}
