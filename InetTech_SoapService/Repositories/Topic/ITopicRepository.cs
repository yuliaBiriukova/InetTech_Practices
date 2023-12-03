using InetTech_SoapService.Entities;

namespace InetTech_SoapService.Repositories;

public interface ITopicRepository
{
    int AddTopic(Topic topic);

    bool DeleteTopic(int topicId);

    List<Topic> GetAllTopics();

    List<Topic> GetTopicsByLevelId(int levelId);

    List<Topic> GetTopicsByName(string name);

    bool UpdateTopic(Topic topic);
}