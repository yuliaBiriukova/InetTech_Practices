using InetTech_Rest_WebApp.ViewModels;
using InetTech_RestClient.Clients;
using Microsoft.AspNetCore.Mvc;

namespace InetTech_Rest_WebApp.Controllers
{
    public class TopicsController : Controller
    {
        private readonly TopicsClient _topicsClient;
        private readonly IEnumerable<Level> levels;

        public TopicsController(TopicsClient topicsClient)
        {
            _topicsClient = topicsClient;
            levels = new List<Level>()
            {
                new Level() { Id = 1, Code = "A1", Name = "Beginner"},
                new Level() { Id = 2, Code = "A2", Name = "Pre-Intermediate"},
                new Level() { Id = 3, Code = "B1", Name = "Intermediate"},
                new Level() { Id = 4, Code = "B2", Name = "Upper-Intermediate"},
            };
        }

        public async Task<IActionResult> IndexAsync([FromQuery] int? levelId)
        {
            var topicsCatalog = new TopicsCatalogViewModel();
            topicsCatalog.Levels = levels;

            if (levelId is not null)
            {
                topicsCatalog.Level = levels.FirstOrDefault(l => l.Id == levelId);
                topicsCatalog.Topics = await _topicsClient.GetTopicsByLevelIdAsync(levelId);
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
                Level = levels.FirstOrDefault(l => l.Id == model.LevelId),
                Name = model.Name,
                Content = model.Content
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
                Id = topic.Id,
                Name = topic.Name,
                Content = topic.Content,
                LevelId = topic.Level.Id,
                Exercises = topic.Exercises.ToList(),
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
                Id = id,
                Name = model.Name,
                Content = model.Content,
                Level = levels.FirstOrDefault(l => l.Id == model.LevelId),
                Exercises = model.Exercises,
            };

            await _topicsClient.UpdateTopicAsync(id, updatedTopic);

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