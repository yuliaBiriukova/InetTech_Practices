using InetTech_SoapService.Const;
using System.Runtime.Serialization;

namespace InetTech_SoapService.Entities;

[DataContract(Namespace = Constants.TOPIC_NAMESPACE)]
public class Topic : Entity
{
    [DataMember(IsRequired = true, Name = "level")]
    public Level Level { get; set; }

    [DataMember(IsRequired = true, Name = "name")]
    public string Name { get; set; }

    [DataMember(IsRequired = true, Name = "content")]
    public string Content { get; set; }

    [DataMember(IsRequired = true, Name = "exercises")]
    public List<Exercise> Exercises { get; set; }

    public override string? ToString()
    {
        var exercisesString = "";
        foreach (var exercise in Exercises)
        {
            exercisesString += "\n" + exercise.ToString() ;
        }

        return $"Topic #{Id}\n" +
            $"{Level}\n" +
            $"Name: {Name}\n" +
            $"Content: {Content}\n\n" +
            $"Exercises: {exercisesString}";
    }
}