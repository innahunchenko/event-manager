using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var domain = new User();
            domain.From(request);
            var result = await service.CreateAsync(domain);
            return result.ToActionResult(id => Ok(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return result.ToActionResult(
                users =>
                {
                    var responses = users.ToResponses();
                    return Ok(responses);
                });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await service.GetByIdAsync(id);
            return result.ToActionResult(
                user =>
                {
                    var response = new UserResponse();
                    response.From(user);
                    return Ok(response);
                });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.DeleteAsync(id);
            return result.ToActionResult(
                () => Ok(new { Message = $"User {id} deleted successfully" }));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserRequest request)
        {
            var domain = new User();
            domain.From(request);

            var result = await service.UpdateAsync(id, domain);
            return result.ToActionResult(updatedUser =>
            {
                var response = new UserResponse();
                response.From(updatedUser);
                return Ok(response);
            });
        }

        [HttpPost("assign-events/{id}")]
        public async Task<IActionResult> AssignEvents(string id, [FromBody] AssignEventsRequest request)
        {
            var result = await service.AssignEventsToUserAsync(id, request.EventIds);
            return result.ToActionResult(() => Ok(new { Message = $"Events successfully assigned to user {id}" }));
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetUserEvents(string id)
        {
            var result = await service.GetUserEventsAsync(id);

            return result.ToActionResult(
                events =>
                {
                    var responses = events.ToResponses();
                    return Ok(responses);
                });
        }
    }
}
