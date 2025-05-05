using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using Microsoft.AspNetCore.Mvc;
using EventManager.API.Common;
using EventManager.API.Services;

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

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TopicRequest request)
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
