using EventManager.API.Database.Models;

namespace EventManager.API.Domain
{
    public class User : DomainBaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Company { get; set; } = default!;
        public float YearsOfExperience { get; set; }
        public UserRole Role { get; set; }

        private readonly List<Guid> eventIds = new();
        public IReadOnlyCollection<Guid>? EventIds => eventIds;

        public User Create(string firstName, 
            string lastName, 
            string position, 
            string company, 
            float yearsOfExperience, 
            UserRole role,
            IEnumerable<Guid> eventIds)
        {
            this.eventIds.Clear();
            this.eventIds.AddRange(eventIds);

            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                Company = company,
                YearsOfExperience = yearsOfExperience,
                Role = role
            };
        }
    }
}
