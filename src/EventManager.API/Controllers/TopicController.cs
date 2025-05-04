using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using EventManager.API.Common;

namespace EventManager.API.Controllers
{
    [Route("api/topics")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService service;

        public TopicController(ITopicService service)
        {
            this.service = service;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TopicRequest request)
        {
            var domain = new Topic();
            domain.From(request);
            var result = await service.CreateAsync(domain);
            return result.ToActionResult(id => Ok(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return result.ToActionResult(
                topis =>
                {
                    var responses = topis.ToResponses();
                    return Ok(responses);
                });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await service.GetByIdAsync(id);
            return result.ToActionResult(
                topic =>
                {
                    var response = new TopicResponse();
                    response.From(topic);
                    return Ok(response);
                });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.DeleteAsync(id);
            return result.ToActionResult(
                () => Ok(new { Message = $"Topic {id} deleted successfully" }));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] TopicRequest request)
        {
            var domain = new Topic();
            domain.From(request);

            var result = await service.UpdateAsync(id, domain);
            return result.ToActionResult(updatedTopic =>
            {
                var response = new TopicResponse();
                response.From(updatedTopic);
                return Ok(response);
            });
        }
    }
}
