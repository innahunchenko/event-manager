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

        public User Create(string firstName, 
                            string lastName, 
                            string position, 
                            string company, 
                            float yearsOfExperience, 
                            UserRole role)
        {
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

        public void AddEvents(IEnumerable<Guid> ids)
        {
            eventIds.Clear();
            eventIds.AddRange(ids);
        }
    }
}
