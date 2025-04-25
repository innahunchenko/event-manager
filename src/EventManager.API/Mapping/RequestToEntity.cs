using EventManager.API.Database.Models;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class RequestToEntityExtensions
    {
        public static void From(this EventRequest request, EventEntity entity)
        {
            request.DateTime = entity.DateTime;
            request.SpeakerId = entity.SpeakerId.ToString();
            request.TopicId = entity.TopicId.ToString();
        }

        public static void From(this TopicRequest request, TopicEntity entity)
        {
            request.Description = entity.Description;
            request.Name = entity.Name;
        }

        public static void From(this UserRequest request, UserEntity entity)
        {
            request.FirstName = entity.FirstName;
            request.LastName = entity.LastName;
            request.Company = entity.Company;
            request.Position = entity.Position;
            request.YearsOfExperience = entity.YearsOfExperience;
            request.Role = entity.Role.ToString();
        }
    }
}
