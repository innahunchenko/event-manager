using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly EventService service;

        public EventController(EventService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EventRequest request)
        {
            var domain = new Event();
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
                @event =>
                {
                    var response = new EventResponse();
                    response.From(@event);
                    return Ok(response);
                });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.DeleteAsync(id);
            return result.ToActionResult(
                () => Ok(new { Message = $"Event {id} deleted successfully" }));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EventRequest request)
        {
            var domain = new Event();
            domain.From(request);

            var result = await service.UpdateAsync(id, domain);
            return result.ToActionResult(updatedEvent =>
            {
                var response = new EventResponse();
                response.From(updatedEvent);
                return Ok(response);
            });
        }
    }
}