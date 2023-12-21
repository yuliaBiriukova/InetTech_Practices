using InetTech_Soap_WebApp.ViewModels;
using InetTech_SoapClient.Behaviors;
using InetTech_SoapClient.TopicService;
using Microsoft.AspNetCore.Mvc;

namespace InetTech_Soap_WebApp.Controllers
{
    public class TopicsController : Controller
    {
        private readonly TopicServiceClient _topicsClient;
        private readonly IEnumerable<Level> levels;

        public TopicsController(TopicServiceClient topicsClient)
        {
            _topicsClient = topicsClient;

            var securityToken = Guid.NewGuid();
            var endpointBehavior = new AuthorizationEndpointBehavior(securityToken);

            _topicsClient.Endpoint.EndpointBehaviors.Remove(typeof(AuthorizationEndpointBehavior));
            _topicsClient.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            levels = new List<Level>()
            {
                new Level() { id = 1, code = "A1", name = "Beginner"},
                new Level() { id = 2, code = "A2", name = "Pre-Intermediate"},
                new Level() { id = 3, code = "B1", name = "Intermediate"},
                new Level() { id = 4, code = "B2", name = "Upper-Intermediate"},
            };
        }

        public async Task<IActionResult> IndexAsync([FromQuery] int? levelId)
        {
            var topicsCatalog = new TopicsCatalogViewModel();
            topicsCatalog.Levels = levels;

            if (levelId is not null)
            {
                topicsCatalog.Level = levels.FirstOrDefault(l => l.id == levelId);
                topicsCatalog.Topics = await _topicsClient.GetTopicsByLevelIdAsync(levelId.Value);
            }

            return View(topicsCatalog);
        }

        public async Task<IActionResult> Topic(int id)
        {
            var topic = await _topicsClient.GetTopicByIdAsync(id);
            return View(topic);
        }

        public IActionResult Add(int? levelId)
        {
            if(levelId == null)
            {
                return View();
            }

            var model = new TopicAddViewModel()
            {
                LevelId = levelId.Value,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TopicAddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var newTopic = new Topic()
            {
                level = levels.FirstOrDefault(l => l.id == model.LevelId),
                name = model.Name,
                content = model.Content
            };

            await _topicsClient.AddTopicAsync(newTopic);

            return RedirectToAction("Index",
                new { levelId = model.LevelId});
        }

        public async Task<IActionResult> Update(int id)
        {
            var topic = await _topicsClient.GetTopicByIdAsync(id);
            var model = new TopicUpdateViewModel()
            {
                Id = topic.id,
                Name = topic.name,
                Content = topic.content,
                LevelId = topic.level.id,
                Exercises = topic.exercises.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TopicUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updatedTopic = new Topic()
            {
                id = id,
                name = model.Name,
                content = model.Content,
                level = levels.FirstOrDefault(l => l.id == model.LevelId),
                exercises = model.Exercises.ToArray(),
            };

            await _topicsClient.UpdateTopicAsync(updatedTopic);

            return RedirectToAction("Index",
                new { levelId = model.LevelId });
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int levelId)
        {
            await _topicsClient.DeleteTopicAsync(id);

            return RedirectToAction("Index",
                new{ levelId });
        }
    }
}