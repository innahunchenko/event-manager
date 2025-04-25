using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;

        public EventController(IEventService service)
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<EventRequest> patchDoc)
        {
            var result = await service.UpdateAsync(id, patchDoc);
            return result.ToActionResult(updatedEvent =>
            {
                var response = new EventResponse();
                response.From(updatedEvent);
                return Ok(response);
            });
        }
    }
}