using System.Xml.Serialization;

namespace InetTech_Practice2.Classes;

[Serializable]
[XmlType(Namespace = "http://eng.grammar/entity/topic")]
public class Entity
{
    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "version", DataType = "integer")]
    public string Version { get; set; }
}