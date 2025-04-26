using EventManager.API.Common;
using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Errors;
using EventManager.API.Mapping;
using EventManager.API.Repositories;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public class EventService : IEventService
    {
        private readonly IBaseRepository<EventEntity> repository;

        public EventService(IBaseRepository<EventEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Event>> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(
                Guid.Parse(id), 
                e => e.Topic,
                e => e.Speaker);
            
            if (entity == null)
                return Result.Failure<Event>(DomainErrors.NotFound<Event>(id));

            var @event = new Event();
            @event.From(entity);
            return @event;
        }

        public async Task<Result<List<Event>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync(e => e.Topic, e => e.Speaker);
            var events = entities.ToDomains();
            return events;
        }

        public async Task<Result<Guid>> CreateAsync(Event @event)
        {
            var entity = new EventEntity();
            entity.From(@event);
            var id = await repository.CreateAsync(entity);
            return id;
        }

        public async Task<Result<Event>> UpdateAsync(string id, JsonPatchDocument<EventRequest> patchDoc)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure<Event>(DomainErrors.NotFound<Event>(id));

            var request = new EventRequest();
            request.From(entity);
            patchDoc.ApplyTo(request);
            entity.From(request);
            entity = await repository.UpdateAsync(entity);
            var @event = new Event();
            @event.From(entity);
            return @event;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure(DomainErrors.NotFound<Event>(id));

            await repository.DeleteAsync(entity);
            return Result.Success();
        }
    }
}
