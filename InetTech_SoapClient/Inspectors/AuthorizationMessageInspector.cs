using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;

namespace InetTech_SoapClient.Helpers;

public class AuthorizationMessageInspector : IClientMessageInspector
{
    private readonly Guid? authToken;

    public AuthorizationMessageInspector(Guid? authToken)
    {
        this.authToken = authToken;
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        var header = MessageHeader.CreateHeader("Authorization", "http://eng.grammar/entity/topic", authToken?.ToString());
        request.Headers.Add(header);
        return null;
    }

    public void AfterReceiveReply(ref Message reply, object correlationState) { }
}
