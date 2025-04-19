using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class RequestToDomain
    {
        public static User ToUser(this UserRequest request)
        {
            var userRole = Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role);
            
            var user = new User().Create(
                request.FirstName,
                request.LastName,
                request.Position,
                request.Company,
                request.YearsOfExperience,
                role);

            return user;
        }

        public static Topic ToTopic(this TopicRequest request)
        {
            return Topic.Create(request.Name, request.Description);
        }

        public static Event ToEvent(this EventRequest request)
        {
            return Event.Create(request.DateTime, 
                new Topic { Id = Guid.Parse(request.TopicId) }, 
                new User { Id = Guid.Parse(request.SpeakerId) });
        }
    }
}
