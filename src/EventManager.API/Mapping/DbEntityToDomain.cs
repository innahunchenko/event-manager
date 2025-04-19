using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DbEntityToDomainExtensions
    {
        public static User ToUser(this UserEntity userEntity)
        {
            var user = new User().Create(
                userEntity.FirstName,
                userEntity.LastName,
                userEntity.Position,
                userEntity.Company,
                userEntity.YearsOfExperience,
                userEntity.Role);

            var eventIds = userEntity.UserEvents?
                .Select(x => x.EventId) ?? Enumerable.Empty<Guid>();

            if (eventIds.Any())
                user.AddEvents(eventIds);

            return user;
        }

        public static Topic ToTopic(this TopicEntity topicEntity)
        {
            return Topic.Create(
                topicEntity.Name,
                topicEntity.Description,
                topicEntity.IsActive);
        }

        public static Event ToEvent(this EventEntity eventEntity)
        {
            return Event.Create(
                eventEntity.DateTime,
                eventEntity.Topic?.ToTopic() ?? new Topic { Id = eventEntity.TopicId },
                eventEntity.Speaker?.ToUser() ?? new User { Id = eventEntity.SpeakerId });
        }
    }
}
