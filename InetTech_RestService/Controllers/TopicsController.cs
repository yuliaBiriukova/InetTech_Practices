using InetTech_RestService.Entities;
using InetTech_RestService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InetTech_RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicsController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Topic>), 200)]
        public IActionResult GetTopicsByLevelId([FromQuery] int levelId)
        {
            return Ok(_topicRepository.GetTopicsByLevelId(levelId));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Topic), 200)]
        public IActionResult GetTopicById([FromRoute] int id)
        {
            var topic = _topicRepository.GetTopicById(id);

            if(topic == null)
            {
                return NotFound($"Topic with id={id} does not exist.");
            }

            return Ok(_topicRepository.GetTopicById(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult AddTopic([FromBody] Topic topic)
        {
            var id = _topicRepository.AddTopic(topic);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateTopic([FromRoute] int id, [FromBody] Topic topic)
        {
            var isUpdated = _topicRepository.UpdateTopic(topic);

            if(!isUpdated)
            {
                return BadRequest($"Failed to update topic with id={id}");
            }

            return Ok(isUpdated);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteTopic([FromRoute] int id)
        {
            var isDeleted = _topicRepository.DeleteTopic(id);

            if (!isDeleted)
            {
                return BadRequest($"Failed to delete topic with id={id}");
            }

            return Ok(isDeleted);
        }
    }
}