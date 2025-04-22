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
            var entity = new EventEntity();
            @event.ToEntity(entity);
            entity = await repository.CreateAsync(entity);
            entity.ToDomain(@event);
            return @event;
        }

        public async Task CreateRangeAsync(IEnumerable<Event> events)
        {
            var entities = events.ToEntities();
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(Event @event)
        {
            var entity = new EventEntity();
            @event.ToEntity(entity);
            await repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync(e => e.Topic, e => e.Speaker);
            var events = entities.ToDomains();
            return events;
        }

        public async Task<Event> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(
                Guid.Parse(id), 
                e => e.Topic, 
                e => e.Speaker);
            
            var @event = new Event();
            entity.ToDomain(@event);

            return @event;
        }

        public async Task<Event> UpdateAsync(Event @event)
        {
            var entity = await repository.GetByIdAsync(@event.Id);
            @event.ToEntity(entity);
            entity = await repository.UpdateAsync(entity);
            entity.ToDomain(@event);
            
            return @event;
        }
    }
}
