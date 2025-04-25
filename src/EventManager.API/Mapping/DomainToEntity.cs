﻿using EventManager.API.Database.Models;
using EventManager.API.Domain;

namespace EventManager.API.Mapping
{
    public static class DomainToDbEntityExtensions
    {
        public static void From(this UserEntity entity, User domain)
        {
            entity.Id = domain.Id;
            entity.Company = domain.Company;
            entity.FirstName = domain.FirstName;
            entity.LastName = domain.LastName;
            entity.Position = domain.Position;
            entity.Role = domain.Role;
            entity.YearsOfExperience = domain.YearsOfExperience;
        }

        public static void AddEvents(this UserEntity entity, List<Guid> eventIds)
        {
            entity.UserEvents.Clear();

            foreach (var eventId in eventIds ?? Enumerable.Empty<Guid>())
            {
                entity.UserEvents.Add(new UserEventEntity
                {
                    UserId = entity.Id,
                    EventId = eventId
                });
            }
        }

        public static void From(this TopicEntity entity, Topic domain)
        {
            entity.Id = domain.Id;
            entity.Description = domain.Description;
            entity.IsActive = domain.IsActive;
            entity.Name = domain.Name;
        }

        public static void From(this EventEntity entity, Event domain)
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
                ev.From(entity);
                return entity;
            }).ToList();
        }

        public static List<TopicEntity> ToEntities(this IEnumerable<Topic> domains)
        {
            return domains.Select(ev =>
            {
                var entity = new TopicEntity();
                entity.From(ev);
                return entity;
            }).ToList();
        }

        public static List<UserEntity> ToEntities(this IEnumerable<User> domains)
        {
            return domains.Select(ev =>
            {
                var entity = new UserEntity();
                entity.From(ev);
                return entity;
            }).ToList();
        }
    }
}
