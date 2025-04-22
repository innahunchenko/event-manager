using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class RequestToDomain
    {
        public static void ToDomain(this UserRequest request, User domain)
        {
            var userRole = Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role);
            domain.Id = Guid.Parse(request.Id);
            domain.FirstName = request.FirstName;
            domain.LastName = request.LastName;
            domain.Position = request.Position;
            domain.Company = request.Company;
            domain.YearsOfExperience = request.YearsOfExperience;
            domain.Role = role;
        }

        public static void ToDomain(this TopicRequest request, Topic domain)
        {
            domain.Id = Guid.Parse(request.Id);
            domain.Name = request.Name;
            domain.Description = request.Description;
        }

        public static void ToDomain(this EventRequest request, Event domain)
        {
            domain.Id = Guid.Parse(request.Id);
            domain.SpeakerId = Guid.Parse(request.SpeakerId);
            domain.TopicId = Guid.Parse(request.TopicId);
            domain.DateTime = request.DateTime;
        }
    }
}
