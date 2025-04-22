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
        private readonly EventService service;

        public EventController(EventService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult<EventResponse>> Create([FromBody] EventRequest request)
        {
            var domain = new Event();
            request.ToDomain(domain);

            var created = await service.CreateAsync(domain);

            var response = new EventResponse();
            created.ToResponse(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetAll()
        {
            var domains = await service.GetAllAsync();
            var responses = domains.ToResponses();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> GetById(string id)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain is null)
                return NotFound();

            var response = new EventResponse();
            domain.ToResponse(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain is null)
                return NotFound();

            await service.DeleteAsync(domain);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<EventRequest> patchDoc)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain == null) return NotFound();

            var request = new EventRequest();
            domain.ToRequest(request);

            patchDoc.ApplyTo(request);

            request.ToDomain(domain);

            var updated = await service.UpdateAsync(domain);
            var response = new EventResponse();
            updated.ToResponse(response);

            return Ok(response);
        }

        //app.MapPatch("/api/events/{id:guid}/deactivate-speaker", async (Guid id, EventService service) =>
        //{
        //    var existing = await service.GetByIdAsync(id);
        //    if (existing is null)
        //        return Results.NotFound();

        //    existing.DeactivateSpeaker();
        //    await service.UpdateAsync(existing);

        //    return Results.NoContent();
        //});
    }
}