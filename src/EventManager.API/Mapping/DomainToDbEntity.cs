using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DomainToDbEntityExtensions
    {
        public static UserEntity ToDbEntity(this User user)
        {
            var entity = new UserEntity()
            {
                Id = user.Id,
                Company = user.Company,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Position = user.Position,
                Role = user.Role,
                YearsOfExperience = user.YearsOfExperience
            };

            entity.UserEvents = user.EventIds?
                .Select(id => new UserEventEntity
                {
                    UserId = user.Id,
                    EventId = id
                }).ToList() ?? new List<UserEventEntity>();

            return entity;
        }

        public static TopicEntity ToEntity(this Topic topic)
        {
            return new TopicEntity()
            {
                Id = topic.Id,
                Description = topic.Description,
                IsActive = topic.IsActive,
                Name = topic.Name
            };
        }

        public static EventEntity ToDbEntity(this Event @event)
        {
            return new EventEntity()
            {
                Id = @event.Id,
                DateTime = @event.DateTime,
                IsSpeakerActive = @event.IsSpeakerActive,
                SpeakerId = @event.Speaker.Id,
                TopicId = @event.Topic.Id
            };
        }
    }
}
