using InetTech_SoapService.Entities;
using InetTech_SoapService.Faults;
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
    [FaultContract(typeof(TopicsEmptyFault))]
    List<Topic> GetTopicsByLevelId(int levelId);

    [OperationContract]
    [FaultContract(typeof(TopicsEmptyFault))]
    List<Topic> GetTopicsByName(string name);

    [OperationContract]
    bool UpdateTopic(Topic topic);
}