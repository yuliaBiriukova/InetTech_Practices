using InetTech_SoapService.DbTable;
using InetTech_SoapService.Entities;
using InetTech_SoapService.Entities.Enums;

namespace InetTech_SoapService.Repositories;

public class TopicRepository : ITopicRepository
{
    private IDbTable<Topic> Topics { get; set; } = new DbTable<Topic>();

    public TopicRepository()
    {
        InitializeTopics();
    }

    public int AddTopic(Topic topic)
    {
        return Topics.Add(topic);
    }

    public bool DeleteTopic(int topicId)
    {
        return Topics.Delete(topicId);
    }

    public List<Topic> GetAllTopics()
    {
        return Topics.GetAll();
    }

    public List<Topic> GetTopicsByLevelId(int levelId)
    {
        return Topics.GetAll().Where(t => t.Level.Id == levelId).ToList();
    }

    public Topic? GetTopicById(int id)
    {
        return Topics.GetById(id);
    }

    public bool UpdateTopic(Topic topic)
    {
        return Topics.Update(topic);
    }

    private void InitializeTopics()
    {
        var levels = new List<Level>()
        {
            new Level() { Id = 1, Code = "A1", Name = "Beginner"},
            new Level() { Id = 2, Code = "A2", Name = "Pre-Intermediate"},
        };

        var topics = new List<Topic>()
        {
            new Topic(){
                Id = 1,
                Name = "Nouns (іменники)",
                Level = levels[0],
                Content = "Nouns (іменники) - це слова, якими ми називаємо людей, місця, речі та ідеї..",
                Exercises = new List<Exercise>()
                {
                    new Exercise() { Id = 1, Type = ExerciseType.Translation, Task = "Будинок", Answer = "House" },
                    new Exercise() { Id = 2, Type = ExerciseType.Translation, Task = "Брат", Answer = "Brother" }
                }
            },
            new Topic(){
                Id = 2,
                Name = "Verbs (дієслова)",
                Level = levels[0],
                Content = "Verbs (дієслова) - це слова дії, які показують, що хтось або щось робить.",
                Exercises = new List<Exercise>()
                {
                    new Exercise() { Id = 1, Type = ExerciseType.Translation, Task = "Ходити", Answer = "To go" },
                    new Exercise() { Id = 2, Type = ExerciseType.Translation, Task = "Читати", Answer = "To read" }
                }
            },
            new Topic(){
                Id = 3,
                Name = "Present Continuous Tense",
                Level = levels[1],
                Content = "Ми використовуємо Present Continuous Tense, коли говоримо про дії, що відбуваються зараз, у момент мовлення.",
                Exercises = new List<Exercise>()
                {
                    new Exercise() {
                        Id = 1,
                        Type = ExerciseType.Translation,
                        Task = "Я зараз дивлюся телевізор",
                        Answer = "I am watching TV now"
                    },
                    new Exercise() {
                        Id = 2,
                        Type = ExerciseType.CorrectTheMistake,
                        Task = "She is play the guitar now",
                        Answer = "She is playing the guitar now"
                    }
                }
            },
            new Topic(){
                Id = 4,
                Name = "Present Simple Tense",
                Level = levels[1],
                Content = "Present Simple Tense використовується, щоб говорити про речі, які відбуваються регулярно, або про факти, які завжди правдиві.",
                Exercises = new List<Exercise>()
                {
                    new Exercise() {
                        Id = 1,
                        Type = ExerciseType.Translation,
                        Task = "Вони обідають о 12 годині",
                        Answer = "They have lunch at 12 o'clock"
                    },
                    new Exercise() {
                        Id = 2,
                        Type = ExerciseType.CorrectTheMistake,
                        Task = "Do he play football on Saturdays?",
                        Answer = "Does he play football on Saturdays?"
                    }
                }
            }
        };

        foreach(var topic in topics)
        {
            AddTopic(topic);
        }
    }
}
