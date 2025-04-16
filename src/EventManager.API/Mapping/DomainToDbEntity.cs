using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DomainToDbEntityExtensions
    {
        public static UserEntity ToEntity(this User user)
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

        public static EventEntity ToEntity(this Event @event)
        {
            var entity = new EventEntity()
            {
                Id = @event.Id,
                Agenda = @event.Agenda,
                DateTime = @event.DateTime,
                IsSpeakerActive = @event.IsSpeakerActive,
                SpeakerId = @event.Speaker.Id,
                TopicId = @event.Topic.Id
            };

            entity.UserEvents = @event.UserIds?
                .Select(id => new UserEventEntity 
                { 
                    UserId = id, 
                    EventId = @event.Id 
                }).ToList() ?? new List<UserEventEntity>();

            return entity;
        }
    }
}
