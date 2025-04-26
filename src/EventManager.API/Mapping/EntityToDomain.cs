using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DbEntityToDomainExtensions
    {
        public static void From(this User domain, UserEntity entity)
        {
            domain.Id = entity.Id;
            domain.FirstName = entity.FirstName;
            domain.LastName = entity.LastName;
            domain.Position = entity.Position;
            domain.Company = entity.Company;
            domain.YearsOfExperience = entity.YearsOfExperience;
            domain.Role = entity.Role;

            var eventIds = entity.UserEvents?
                .Select(x => x.EventId) ?? Enumerable.Empty<Guid>();

            if (eventIds.Any())
                domain.AddEventIds(eventIds);
        }

        public static void From(this Topic domain, TopicEntity entity)
        {
            domain.Id = entity.Id;
            domain.Name = entity.Name;
            domain.Description = entity.Description;
            domain.IsActive = entity.IsActive;
        }

        public static void From(this Event domain, EventEntity entity)
        {
            domain.Id = entity.Id;
            domain.DateTime = entity.DateTime;
            domain.TopicId = entity.TopicId;
            domain.SpeakerId = entity.SpeakerId;

            if (entity.Speaker != null)
            {
                domain.Speaker ??= new User();
                domain.Speaker.From(entity.Speaker);
            }

            if (entity.Topic != null)
            {
                domain.Topic ??= new Topic();
                domain.Topic.From(entity.Topic);
            }
        }

        public static List<User> ToDomains(this IEnumerable<UserEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new User();
                domain.From(entity);
                return domain;
            }).ToList();
        }

        public static List<Topic> ToDomains(this IEnumerable<TopicEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new Topic();
                domain.From(entity);
                return domain;
            }).ToList();
        }

        public static List<Event> ToDomains(this IEnumerable<EventEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new Event();
                domain.From(entity);
                return domain;
            }).ToList();
        }
    }
}
