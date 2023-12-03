using System.Runtime.Serialization;

namespace InetTech_SoapService.Entities;

[DataContract]
public class Profile
{
    public Profile() { }
    [DataMember]
    public int ProfileID { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string HomeAddress { get; set; }
}
