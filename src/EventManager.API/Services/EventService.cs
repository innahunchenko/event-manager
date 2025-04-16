using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;

namespace EventManager.API.Services
{
    public class EventService : IBaseService<Event>
    {
        private readonly IBaseRepository<EventEntity> repository;

        public EventService(IBaseRepository<EventEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Event> CreateAsync(Event @event)
        {
            var dbEntity = @event.ToEntity();
            dbEntity = await repository.CreateAsync(dbEntity);
            @event = dbEntity.ToDomain();
            return @event;
        }

        public async Task CreateRangeAsync(IEnumerable<Event> events)
        {
            var entities = events.Select(u => u.ToEntity()).ToList();
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var events = entities.Select(u => u.ToDomain()).ToList();
            return events;
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);
            var @event = entity.ToDomain();
            return @event;
        }

        public async Task UpdateAsync(Event @event)
        {
            var entity = @event.ToEntity();
            await repository.UpdateAsync(entity);
        }
    }
}
