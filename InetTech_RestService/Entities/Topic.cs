using InetTech_RestService.Const;
using System.Xml.Serialization;

namespace InetTech_RestService.Entities;

[Serializable]
[XmlType(Namespace = Constants.TOPIC_NAMESPACE)]
public class Topic : Entity
{
    [XmlElement("level")]
    public Level Level { get; set; }

    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("content")]
    public string Content { get; set; }

    [XmlArray("exercises")]
    [XmlArrayItem("exercise", IsNullable = false)]
    public List<Exercise>? Exercises { get; set; }
}