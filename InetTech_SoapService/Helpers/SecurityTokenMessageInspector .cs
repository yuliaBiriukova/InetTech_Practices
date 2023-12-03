using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Runtime.Serialization;
using SoapCore.ServiceModel;
using SoapCore.Extensibility;

namespace InetTech_SoapService.Helpers;

public class SecurityTokenMessageInspector : IMessageInspector
{
    public object AfterReceiveRequest(ref Message message)
    {
        var securityTokenHeader = message.Headers.GetHeader<string>("SecurityToken", "http://eng.grammar/entity/topic");

        if (string.IsNullOrEmpty(securityTokenHeader))
        {
            
        }

        return null;
    }

    public void BeforeSendReply(ref Message reply, object correlationState)
    {
        throw new NotImplementedException();
    }
}

[DataContract]
public class FaultDetails
{
    [DataMember]
    public string Code { get; set; }

    [DataMember]
    public string Reason { get; set; }
}