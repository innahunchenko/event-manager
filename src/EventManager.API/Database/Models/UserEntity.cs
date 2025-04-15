namespace EventManager.API.Database.Models
{
    public class UserEntity : DbEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Company { get; set; } = default!;
        public float YearsOfExperience { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Attendee = 0,
        Speaker = 1
    }
}
