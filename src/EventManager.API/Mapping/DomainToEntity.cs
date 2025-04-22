using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DomainToDbEntityExtensions
    {
        public static void ToEntity(this User domain, UserEntity entity)
        {
            entity.Id = domain.Id;
            entity.Company = domain.Company;
            entity.FirstName = domain.FirstName;
            entity.LastName = domain.LastName;
            entity.Position = domain.Position;
            entity.Role = domain.Role;
            entity.YearsOfExperience = domain.YearsOfExperience;
        }

        public static void ToEntity(this Topic domain, TopicEntity entity)
        {
            entity.Id = domain.Id;
            entity.Description = domain.Description;
            entity.IsActive = domain.IsActive;
            entity.Name = domain.Name;
        }

        public static void ToEntity(this Event domain, EventEntity entity)
        {
            entity.Id = domain.Id;
            entity.SpeakerId = domain.SpeakerId.Value;
            entity.TopicId = domain.TopicId.Value;
            entity.DateTime = domain.DateTime;
        }

        public static List<EventEntity> ToEntities(this IEnumerable<Event> domains)
        {
            return domains.Select(ev =>
            {
                var entity = new EventEntity();
                ev.ToEntity(entity);
                return entity;
            }).ToList();
        }

        public static List<TopicEntity> ToEntities(this IEnumerable<Topic> domains)
        {
            return domains.Select(ev =>
            {
                var entity = new TopicEntity();
                ev.ToEntity(entity);
                return entity;
            }).ToList();
        }

        public static List<UserEntity> ToEntities(this IEnumerable<User> domains)
        {
            return domains.Select(ev =>
            {
                var entity = new UserEntity();
                ev.ToEntity(entity);
                return entity;
            }).ToList();
        }
    }
}
