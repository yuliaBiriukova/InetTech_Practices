using InetTech_SoapClient.Helpers;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace InetTech_SoapClient.Behaviors;

public class AuthorizationEndpointBehavior : IEndpointBehavior
{
    private readonly Guid? authToken;

    public AuthorizationEndpointBehavior(Guid? authToken)
    {
        this.authToken = authToken;
    }

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        clientRuntime.ClientMessageInspectors.Add(new AuthorizationMessageInspector(authToken));
    }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

    public void Validate(ServiceEndpoint endpoint) { }
}