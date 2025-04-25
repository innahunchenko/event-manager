using EventManager.API.Database.Models;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class EntityToRequestExtensions
    {
        public static void From(this EventEntity entity, EventRequest request)
        {
            entity.SpeakerId = Guid.Parse(request.SpeakerId);
            entity.TopicId = Guid.Parse(request.TopicId);
            entity.DateTime = request.DateTime;
        }

        public static void From(this TopicEntity entity, TopicRequest request)
        {
            entity.Name = request.Name;
            entity.Description = request.Description;
        }

        public static void From(this UserEntity entity, UserRequest request)
        {
            var userRole = Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role);
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Position = request.Position;
            entity.Company = request.Company;
            entity.YearsOfExperience = request.YearsOfExperience;
            entity.Role = role;
        }

    }
}
