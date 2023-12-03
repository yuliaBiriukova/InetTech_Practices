using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;

namespace InetTech_SoapClient.Helpers;

public class SecurityTokenMessageInspector : IClientMessageInspector
{
    private readonly Guid securityToken;

    public SecurityTokenMessageInspector(Guid securityToken)
    {
        this.securityToken = securityToken;
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        var header = MessageHeader.CreateHeader("SecurityToken", "http://eng.grammar/entity/topic", securityToken.ToString());
        request.Headers.Add(header);

        return null;
    }

    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
        // Not needed for this example
    }
}
