using InetTech_RestService.Const;
using System.Xml.Serialization;

namespace InetTech_RestService.Entities;

[Serializable]
[XmlType(Namespace = Constants.TOPIC_NAMESPACE)]
public class Entity
{
    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }
}