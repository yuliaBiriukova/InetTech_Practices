using InetTech_SoapService.Const;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InetTech_SoapService.Entities;

[DataContract(Namespace = Constants.TOPIC_NAMESPACE)]
public class Entity
{
    [DataMember(IsRequired = true, Name = "id")]
    public int Id { get; set; }
}