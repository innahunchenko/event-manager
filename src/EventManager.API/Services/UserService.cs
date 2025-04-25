using EventManager.API.Common;
using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<User>> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id), u => u.UserEvents);
            if (entity == null)
                return Result.Failure<User>(DomainErrors.NotFound<User>(id));

            var user = new User();
            user.From(entity);
            return user;
        }

        public async Task<Result<List<User>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var users = entities.ToDomains();
            return users;
        }

        public async Task<Result<List<Event>>> GetUserEventsAsync(string userId)
        {
            var userEntity = await repository.GetByIdAsync(Guid.Parse(userId));
            if (userEntity == null)
                return Result.Failure<List<Event>>(DomainErrors.NotFound<User>(userId));

            var user = new User();
            user.From(userEntity);
            var entities = await repository.GetUserEventsAsync(user.EventIds.ToList());
            var events = entities.ToDomains();
            return events;
        }

        public async Task<Result<Guid>> CreateAsync(User user)
        {
            var entity = new UserEntity();
            entity.From(user);
            var id = await repository.CreateAsync(entity);
            return id;
        }

        public async Task<Result<User>> UpdateAsync(string id, JsonPatchDocument<UserRequest> patchDoc)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure<User>(DomainErrors.NotFound<User>(id));

            var request = new UserRequest();
            request.From(entity);
            patchDoc.ApplyTo(request);
            entity.From(request);
            entity = await repository.UpdateAsync(entity);
            var user = new User();
            user.From(entity);
            return user;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure(DomainErrors.NotFound<User>(id));

            await repository.DeleteAsync(entity);
            return Result.Success();
        }

        public async Task<Result> AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(userId));
            if (entity == null)
                return Result.Failure(DomainErrors.NotFound<User>(userId));

            var evIds = new List<Guid>();
            eventIds.ToList().ForEach(eventId =>  evIds.Add(Guid.Parse(eventId)));
            entity.AddEvents(evIds);
            var result = await repository.AssignEventsToUserAsync(entity);
            return result ? Result.Success()
                : Result.Failure(DomainErrors.EventsAssignmentError);
        }
    }
}
