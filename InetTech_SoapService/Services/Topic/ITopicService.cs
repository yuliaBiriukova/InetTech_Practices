using InetTech_SoapService.Entities;
using System.ServiceModel;

namespace InetTech_SoapService.Services;

[ServiceContract(Namespace = "http://eng.grammar/entity/topic")]
public interface ITopicService
{
    [OperationContract]
    int AddTopic(Topic topic);

    [OperationContract]
    bool DeleteTopic(int id);

    [OperationContract]
    List<Topic> GetAllTopics();

    [OperationContract]
    List<Topic> GetTopicsByLevelId(int levelId);

    [OperationContract]
    Topic GetTopicById(int id);

    [OperationContract]
    bool UpdateTopic(Topic topic);
}