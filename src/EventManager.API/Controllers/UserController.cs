using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<ActionResult<string>> Create([FromBody] UserRequest request)
        {
            var domain = new User();
            domain.From(request);
            var id = await service.CreateAsync(domain);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            var domains = await service.GetAllAsync();
            var responses = domains.ToResponses();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(string id)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain is null)
                return NotFound();

            var response = new UserResponse();
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
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<UserRequest> patchDoc)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain == null) return NotFound();

            var request = new UserRequest();
            domain.ToRequest(request);

            patchDoc.ApplyTo(request);
            domain.From(request);

            var updated = await service.UpdateAsync(domain);
            var response = new UserResponse();
            updated.ToResponse(response);

            return Ok(response);
        }

        [HttpPost("assign-events/{id}")]
        public async Task<IActionResult> AssignEvents(string id, [FromBody] AssignEventsRequest request)
        {
            var existing = await service.GetByIdAsync(id);
            if (existing is null)
                return NotFound();

            await service.AssignEventsToUserAsync(id, request.EventIds);
            return NoContent();
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetUserEvents(string id)
        {
            var existing = await service.GetByIdAsync(id);
            if (existing is null)
                return NotFound();

            var events = await service.GetUserEventsAsync(id);
            var responses = events.ToResponses();
            return Ok(responses);
        }
    }
}
