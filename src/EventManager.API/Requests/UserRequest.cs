namespace EventManager.API.Requests
{
    public class UserRequest : IRequest
    {
        public string Id { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public string Company { get; set; } = "";
        public float YearsOfExperience { get; set; }
        public string Role { get; set; } = "";
    }
}
