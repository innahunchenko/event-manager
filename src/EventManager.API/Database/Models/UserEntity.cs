namespace EventManager.API.Database.Models
{
    public class UserEntity : DbBaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Company { get; set; } = default!;
        public float YearsOfExperience { get; set; }
        public UserRole Role { get; set; }
        public ICollection<UserEventEntity> UserEvents { get; set; } = new List<UserEventEntity>();
    }

    public enum UserRole
    {
        Attendee = 0,
        Speaker = 1
    }
}
