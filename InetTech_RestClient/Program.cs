using InetTech_RestClient.Clients;

var topicsClient = new TopicsClient(new HttpClient());

try
{
    var levelId = 1;
    await GetLevelTopics(topicsClient, levelId);

    var newTopicId = await AddTopic(topicsClient);

    var newTopic = await GetTopicById(topicsClient, newTopicId);

    await GetLevelTopics(topicsClient, levelId);

    newTopic.Name = "Pronouns Updated";

    var updatedTopic = await UpdateTopic(topicsClient, newTopic);

    await DeleteTopic(topicsClient, updatedTopic.Id);

    await GetLevelTopics(topicsClient, levelId);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n------------------ Exeption handling demonstration ------------------\n");

try
{
    var topicId = 10;
    var topic = await GetTopicById(topicsClient, topicId);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


static async Task GetLevelTopics(TopicsClient topicClient, int levelId)
{
    var topics = await topicClient.GetTopicsByLevelIdAsync(levelId);
    if (topics != null)
    {
        Console.WriteLine($"Topics amount in level {levelId}: {topics.ToList().Count}\n");
    }
}

static async Task<int> AddTopic(TopicsClient topicClient)
{
    var newTopic = new Topic()
    {
        Name = "Pronouns",
        Level = new Level() { Id = 1, Code = "A1", Name = "Beginner" },
        Content = "Pronouns are used instead of nouns.",
        Exercises = new Exercise[]
            {
                new Exercise() { Id = 1, Type = ExerciseType.Translation, Task = "Їхній", Answer = "Their"},
                new Exercise() { Id = 2, Type = ExerciseType.Translation, Task = "Вона", Answer = "She"}
            }
    };

    var newTopicId = await topicClient.AddTopicAsync(newTopic);
    Console.WriteLine($"New topic id: {newTopicId}\n");

    return newTopicId;
}

static async Task<Topic> GetTopicById(TopicsClient topicClient, int id)
{
    var topic = await topicClient.GetTopicByIdAsync(id);
    Console.WriteLine($"New topic:\n" +
        $"Name: {topic.Name}\n" +
        $"Level: {topic.Level.Code} {topic.Level.Name}\n" +
        $"Content: {topic.Content}\n");
    return topic;
}

static async Task<Topic> UpdateTopic(TopicsClient topicClient, Topic topic)
{
    var isUpdated = await topicClient.UpdateTopicAsync(topic.Id, topic);
    if (isUpdated)
    {
        Console.WriteLine($"Topic with id={topic.Id} is updated.\n");
    }

    var updatedTopic = await topicClient.GetTopicByIdAsync(topic.Id);
    Console.WriteLine($"Updated topic:\n" +
        $"Name: {topic.Name}\n" +
        $"Level: {topic.Level.Code} {topic.Level.Name}\n" +
        $"Content: {topic.Content}\n");
    return updatedTopic;
}

static async Task DeleteTopic(TopicsClient topicClient, int id)
{
    var isDeleted = await topicClient.DeleteTopicAsync(id);
    if (isDeleted)
    {
        Console.WriteLine($"Topic with id={id} is deleted.\n");
    }
}