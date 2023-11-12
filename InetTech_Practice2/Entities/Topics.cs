using InetTech_Practice2.Classes;
using System.Xml.Serialization;

[Serializable()]
[XmlRoot(Namespace="http://eng.grammar/entity/topic", ElementName = "topics", IsNullable =false)]
public class Topics 
{
    [XmlElement("topic")]
    public List<Topic> TopicsList { get; set; }

    public Topics() 
    {
        TopicsList = new List<Topic>();
    }

    public Topics(List<Topic> topicsList)
    {
        TopicsList = topicsList;
    }

    public override string? ToString()
    {
        var topicsString = "";
        foreach (var topic in TopicsList)
        {
            topicsString += "\n" + topic.ToString();
        }
        return topicsString;
    }
}