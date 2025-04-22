using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DbEntityToDomainExtensions
    {
        public static void ToDomain(this UserEntity entity, User domain)
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

        public static void ToDomain(this TopicEntity entity, Topic domain)
        {
            domain.Id = entity.Id;
            domain.Name = entity.Name;
            domain.Description = entity.Description;
            domain.IsActive = entity.IsActive;
        }

        public static void ToDomain(this EventEntity entity, Event domain)
        {
            domain.Id = entity.Id;
            domain.DateTime = entity.DateTime;
            domain.TopicId = entity.TopicId;
            domain.SpeakerId = entity.SpeakerId;
            domain.IsSpeakerActive = entity.IsSpeakerActive;

            if (entity.Speaker != null)
                entity.Speaker.ToDomain(domain.Speaker);

            if (entity.Topic != null)
                entity.Topic.ToDomain(domain.Topic);
        }

        public static List<User> ToDomains(this IEnumerable<UserEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new User();
                entity.ToDomain(domain);
                return domain;
            }).ToList();
        }

        public static List<Topic> ToDomains(this IEnumerable<TopicEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new Topic();
                entity.ToDomain(domain);
                return domain;
            }).ToList();
        }

        public static List<Event> ToDomains(this IEnumerable<EventEntity> entities)
        {
            return entities.Select(entity =>
            {
                var domain = new Event();
                entity.ToDomain(domain);
                return domain;
            }).ToList();
        }
    }
}
