using System.Xml.Serialization;

namespace InetTech_Practice2.Classes;

[Serializable]
[XmlType(Namespace = "http://eng.grammar/entity/topic")]
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
    public List<Exercise> Exercises { get; set; }

    public override string? ToString()
    {
        var exercisesString = "";
        foreach (var exercise in Exercises)
        {
            exercisesString += "\n" + exercise.ToString() ;
        }

        return $"Topic #{Id} version {Version}\n" +
            $"{Level}\n" +
            $"Name: {Name}\n" +
            $"Content: {Content}\n\n" +
            $"Exercises: {exercisesString}";
    }
}