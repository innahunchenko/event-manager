namespace EventManager.API.Responses
{
    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public float YearsOfExperience { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
