using InetTech_RestService.Entities;

namespace InetTech_RestService.Repositories;

public interface ITopicRepository
{
    int AddTopic(Topic topic);

    bool DeleteTopic(int topicId);

    List<Topic> GetAllTopics();

    List<Topic> GetTopicsByLevelId(int levelId);

    Topic? GetTopicById(int id);

    bool UpdateTopic(Topic topic);
}