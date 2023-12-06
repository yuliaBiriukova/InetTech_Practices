using InetTech_RestService.Const;
using System.Xml.Serialization;

namespace InetTech_RestService.Entities;

[Serializable]
[XmlType(Namespace = Constants.TOPIC_NAMESPACE)]
public class Level : Entity
{
    [XmlElement("code")]
    public string Code { get; set; }

    [XmlElement("name")]
    public string Name { get; set; }
}