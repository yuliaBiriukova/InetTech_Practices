using System.Xml.Serialization;

namespace InetTech_Practice2.Classes;

[Serializable]
[XmlType(Namespace = "http://eng.grammar/entity/topic")]
public class Level : Entity
{
    [XmlElement("code")]
    public string Code { get; set; }

    [XmlElement("name")]
    public string Name { get; set; }

    public override string? ToString()
    {
        return $"Level #{Id}: {Code} {Name}";
    }
}