using System.Runtime.Serialization;

namespace InetTech_SoapService.Faults;

[DataContract]
public class TopicsEmptyFault
{
    public TopicsEmptyFault(string message)
    {
        Message = message;
    }

    [DataMember]
    public string Message { get; set; }
}