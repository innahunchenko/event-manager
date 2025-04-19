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
            var entity = @event.ToDbEntity();
            entity = await repository.CreateAsync(entity);
            @event = entity.ToEvent();
            return @event;
        }

        public async Task CreateRangeAsync(IEnumerable<Event> events)
        {
            var entities = events.Select(u => u.ToDbEntity()).ToList();
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(Event @event)
        {
            var entity = @event.ToDbEntity();
            await repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var events = entities.Select(u => u.ToEvent()).ToList();
            return events;
        }

        public async Task<Event> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            var @event = entity.ToEvent();
            return @event;
        }

        public async Task<Event> UpdateAsync(Event @event)
        {
            var entity = @event.ToDbEntity();
            entity = await repository.UpdateAsync(entity);
            var updatedEvent = entity.ToEvent();
            return updatedEvent;
        }
    }
}
