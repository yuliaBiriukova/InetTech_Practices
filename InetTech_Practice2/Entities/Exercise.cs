using InetTech_Practice2.Entities.Enums;
using System.Xml.Serialization;

namespace InetTech_Practice2.Classes;

[Serializable]
[XmlType(Namespace = "http://eng.grammar/entity/topic")]
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

    public override string? ToString()
    {
        return $"Exercise #{Id} {Type}\n" +
            $"Topic: #{TopicId}\n" +
            $"Task: {Task}\n" +
            $"Answer: {Answer}\n";
    }
}