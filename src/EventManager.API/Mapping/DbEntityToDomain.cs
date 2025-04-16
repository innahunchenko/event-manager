using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DbEntityToDomainExtensions
    {
        public static User ToDomain(this UserEntity userEntity)
        {
            var eventIds = userEntity.UserEvents?
                .Select(x => x.EventId) ?? Enumerable.Empty<Guid>();

            var user = new User().Create(
                userEntity.FirstName,
                userEntity.LastName,
                userEntity.Position,
                userEntity.Company,
                userEntity.YearsOfExperience,
                userEntity.Role,
                eventIds);

            return user;
        }

        public static Topic ToDomain(this TopicEntity topicEntity)
        {
            var topic = Topic.Create(
                topicEntity.Name,
                topicEntity.Description,
                topicEntity.IsActive);

            return topic;
        }

        public static Event ToDomain(this EventEntity eventEntity)
        {
            var userIds = eventEntity.UserEvents?
                .Select(e => e.UserId) ?? Enumerable.Empty<Guid>();

            var @event = Event.Create(
                eventEntity.DateTime,
                eventEntity.Agenda,
                userIds,
                eventEntity.IsSpeakerActive);

            return @event;
        }
    }
}
