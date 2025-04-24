using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;

namespace EventManager.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var userEntity = await repository.GetByIdAsync(Guid.Parse(id), u => u.UserEvents);
            var user = new User();
            user.From(userEntity);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var users = entities.ToDomains();
            return users;
        }

        public async Task<List<Event>> GetUserEventsAsync(string userId)
        {
            var user = await GetByIdAsync(userId);
             var entities = await repository.GetUserEventsAsync(user.EventIds.ToList());
            var events = entities.ToDomains();
            return events;
        }

        public async Task<Guid> CreateAsync(User user)
        {
            var entity = new UserEntity();
            entity.From(user);
            var id = await repository.CreateAsync(entity);
            return id;
        }

        public async Task CreateRangeAsync(IEnumerable<User> users)
        {
            var entities = users.ToEntities();
            await repository.CreateRangeAsync(entities);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var entity = await repository.GetByIdAsync(user.Id);
            entity.From(user);
            entity = await repository.UpdateAsync(entity);
            user.From(entity);
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            var entity = await repository.GetByIdAsync(user.Id);
            entity.From(user);
            await repository.DeleteAsync(entity);
        }

        public async Task AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(userId));
            var evIds = new List<Guid>();
            eventIds.ToList().ForEach(eventId =>  evIds.Add(Guid.Parse(eventId)));
            var user = await GetByIdAsync(userId);
            user.AddEventIds(evIds);
            entity.From(user);
            user.MapUserEvents(entity);
            await repository.AssignEventsToUserAsync(entity);
        }
    }
}
