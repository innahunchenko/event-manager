using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/topics")]
    public class TopicController : ControllerBase
    {
        private readonly TopicService service;

        public TopicController(TopicService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult<string>> Create([FromBody] TopicRequest request)
        {
            var domain = new Topic();
            domain.From(request);
            var id = await service.CreateAsync(domain);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicResponse>>> GetAll()
        {
            var domains = await service.GetAllAsync();
            var responses = domains.ToResponses();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponse>> GetById(string id)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain is null)
                return NotFound();

            var response = new TopicResponse();
            response.From(domain);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<TopicRequest> patchDoc)
        {
            var domain = await service.GetByIdAsync(id);
            if (domain == null) return NotFound();

            var request = new TopicRequest();
            request.From(domain);
            patchDoc.ApplyTo(request);
            domain.From(request);
            var updated = await service.UpdateAsync(domain);
            var response = new TopicResponse();
            response.From(updated);
            return Ok(response);
        }
    }
}
