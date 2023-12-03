using InetTech_SoapService.Entities;
using InetTech_SoapService.Faults;
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
            throw new FaultException<TopicsEmptyFault>(new TopicsEmptyFault($"There are no topics with levelId={levelId}."),
                new FaultReason($"Returned empty list of topics."),
                new FaultCode("TopicsEmpty"), null);
        }
        return topics;
    }

    public List<Topic> GetTopicsByName(string name)
    {
        throw new NotImplementedException();
    }

    public bool UpdateTopic(Topic topic)
    {
        return _topicRepository.UpdateTopic(topic);
    }
}