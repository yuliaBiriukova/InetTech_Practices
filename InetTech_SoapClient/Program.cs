using InetTech_SoapClient.Behaviors;
using System.ServiceModel;
using InetTech_SoapClient.TopicService;

using (var topicClient = new TopicServiceClient())
{
    try
    {
        var securityToken = Guid.NewGuid();
        var endpointBehavior = new AuthorizationEndpointBehavior(securityToken);

        topicClient.Endpoint.EndpointBehaviors.Add(endpointBehavior);

        var levelId = 1;
        await GetLevelTopics(topicClient, levelId);

        var newTopicId = await AddTopic(topicClient);

        var newTopic = await GetTopicById(topicClient, newTopicId);

        await GetLevelTopics(topicClient, levelId);

        newTopic.name = "Pronouns Updated";

        var updatedTopic = await UpdateTopic(topicClient, newTopic);

        await DeleteTopic(topicClient, updatedTopic.id);

        await GetLevelTopics(topicClient, levelId);

    }
    catch (FaultException ex)
    {
        Console.WriteLine($"Fault code: {ex.Code.Name}. Fault reason: {ex.Reason}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

using (var topicClient = new TopicServiceClient())
{
    Console.WriteLine("\n------------------ No authorization demonstration ------------------\n");

    try
    {
        var endpointBehavior = new AuthorizationEndpointBehavior(null);
        topicClient.Endpoint.EndpointBehaviors.Add(endpointBehavior);

        var levelId = 1;
        await GetLevelTopics(topicClient, levelId);
    }
    catch (FaultException ex)
    {
        Console.WriteLine($"Fault code: {ex.Code.Name}. Fault reason: {ex.Reason}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

using (var topicClient = new TopicServiceClient())
{
    Console.WriteLine("\n------------------ Faults demonstration ------------------\n");

    try
    {
        var securityToken = Guid.NewGuid();
        var endpointBehavior = new AuthorizationEndpointBehavior(securityToken);
        topicClient.Endpoint.EndpointBehaviors.Add(endpointBehavior);

        var topicId = 10;
        var topic = await GetTopicById(topicClient, topicId);
        
    }
    catch (FaultException ex)
    {
        Console.WriteLine($"Fault code: {ex.Code.Name}. Fault reason: {ex.Reason}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

static async Task GetLevelTopics(TopicServiceClient topicClient, int levelId)
{
    var topics = await topicClient.GetTopicsByLevelIdAsync(levelId);
    if (topics != null)
    {
        Console.WriteLine($"Topics amount in level {levelId}: {topics.Length}\n");
    }
}

static async Task<int> AddTopic(TopicServiceClient topicClient)
{
    var newTopic = new Topic()
    {
        name = "Pronouns",
        level = new Level() { id = 1, code = "A1", name = "Beginner" },
        content = "Pronouns are used instead of nouns.",
        exercises = new Exercise[]
            {
                new Exercise() { id = 1, type = ExerciseType.Translation, task = "Їхній", answer = "Their"},
                new Exercise() { id = 2, type = ExerciseType.Translation, task = "Вона", answer = "She"}
            }
    };

    var newTopicId = await topicClient.AddTopicAsync(newTopic);
    Console.WriteLine($"New topic id: {newTopicId}\n");

    return newTopicId;
}

static async Task<Topic> GetTopicById(TopicServiceClient topicClient, int id)
{
    var topic = await topicClient.GetTopicByIdAsync(id);
    Console.WriteLine($"New topic:\n" +
        $"Name: {topic.name}\n" +
        $"Level: {topic.level.code} {topic.level.name}\n" +
        $"Content: {topic.content}\n");
    return topic;
}

static async Task<Topic> UpdateTopic(TopicServiceClient topicClient, Topic topic)
{
    var isUpdated = await topicClient.UpdateTopicAsync(topic);
    if (isUpdated)
    {
        Console.WriteLine($"Topic with id={topic.id} is updated.\n");
    }

    var updatedTopic = await topicClient.GetTopicByIdAsync(topic.id);
    Console.WriteLine($"Updated topic:\n" +
        $"Name: {topic.name}\n" +
        $"Level: {topic.level.code} {topic.level.name}\n" +
        $"Content: {topic.content}\n");
    return updatedTopic;
}

static async Task DeleteTopic(TopicServiceClient topicClient, int id)
{
    var isDeleted = await topicClient.DeleteTopicAsync(id);
    if (isDeleted)
    {
        Console.WriteLine($"Topic with id={id} is deleted.\n");
    }
}