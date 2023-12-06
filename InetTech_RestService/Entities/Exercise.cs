using InetTech_RestService.Const;
using InetTech_RestService.Entities.Enums;
using System.Xml.Serialization;

namespace InetTech_RestService.Entities;

[Serializable]
[XmlType(Namespace = Constants.TOPIC_NAMESPACE)]
public class Exercise : Entity
{
    [XmlElement("topicId")]
    public int TopicId { get; set; }

    [XmlElement("type")]
    public ExerciseType Type { get; set; }

    [XmlElement("task")]
    public string Task { get; set; }

    [XmlElement("answer")]
    public string Answer { get; set; }
}