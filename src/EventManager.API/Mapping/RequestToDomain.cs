using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class RequestToDomain
    {
        public static void From(this User domain, UserRequest request)
        {
            var userRole = Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role);
            domain.FirstName = request.FirstName;
            domain.LastName = request.LastName;
            domain.Position = request.Position;
            domain.Company = request.Company;
            domain.YearsOfExperience = request.YearsOfExperience;
            domain.Role = role;
        }

        public static void From(this Topic domain, TopicRequest request)
        {
            domain.Name = request.Name;
            domain.Description = request.Description;
        }

        public static void From(this Event domain, EventRequest request)
        {
            domain.SpeakerId = Guid.Parse(request.SpeakerId);
            domain.TopicId = Guid.Parse(request.TopicId);
            domain.DateTime = request.DateTime;
        }
    }
}
