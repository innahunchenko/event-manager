using EventManager.API.Domain;
using EventManager.API.Responses;

namespace EventManager.API.Mapping
{
    public static class DomainToResponse
    {
        public static UserResponse ToResponse(this User user)
        {
            return new UserResponse(
                user.FirstName,
                user.LastName,
                user.Position,
                user.Company,
                user.YearsOfExperience,
                user.Role.ToString());
        }

        public static TopicResponse ToResponse(this Topic topic)
        {
            return new TopicResponse(
                topic.Description,
                topic.Name);
        }

        public static EventResponse ToResponse(this Event @event)
        {
            return new EventResponse
            (
                @event.Speaker.FirstName,
                @event.Speaker.LastName,
                @event.Speaker.Position,
                @event.Speaker.Company,
                @event.Topic.Name,
                @event.DateTime
            );
        }
    }
}
