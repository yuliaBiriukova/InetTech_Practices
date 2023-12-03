using InetTech_SoapService.Entities;
using InetTech_SoapService.Repositories;
using System.ServiceModel;

namespace InetTech_SoapService.Services;

public class TopicService : ITopicService
{
    private readonly ITopicRepository _topicRepository;

    public TopicService(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public int AddTopic(Topic topic)
    {
        return _topicRepository.AddTopic(topic);
    }

    public bool DeleteTopic(int id)
    {
        return _topicRepository.DeleteTopic(id);
    }

    public List<Topic> GetAllTopics()
    {
        return _topicRepository.GetAllTopics();
    }

    public List<Topic> GetTopicsByLevelId(int levelId)
    {
        var topics = _topicRepository.GetTopicsByLevelId(levelId);
        if(!topics.Any()) 
        {
            throw new FaultException(
                new FaultReason($"Returned empty list of topics; there are no topics with levelId={levelId}"),
                new FaultCode("TopicsEmpty"), 
                null);
        }
        return topics;
    }

    public Topic GetTopicById(int id)
    {
        var topic = _topicRepository.GetTopicById(id);
        if(topic is null)
        {
            throw new FaultException(
               new FaultReason($"Returned empty topic; there is no topic with id={id}"),
               new FaultCode("MissingTopic"),
               null);
        }
        return topic;
    }

    public bool UpdateTopic(Topic topic)
    {
        return _topicRepository.UpdateTopic(topic);
    }
}