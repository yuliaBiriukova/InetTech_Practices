using InetTech_SoapService.Utils;
using System.Runtime.Serialization;

namespace InetTech_SoapService.Entities;

[DataContract(Namespace = Constants.TOPIC_NAMESPACE)]
public class Level : Entity
{
    [DataMember(IsRequired = true, Name = "code")]
    public string Code { get; set; }

    [DataMember(IsRequired = true, Name = "name")]
    public string Name { get; set; }

    public override string? ToString()
    {
        return $"Level #{Id}: {Code} {Name}";
    }
}