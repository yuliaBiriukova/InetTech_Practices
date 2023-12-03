using InetTech_SoapClient.Helpers;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace InetTech_SoapClient.Behaviors;

public class SecurityTokenEndpointBehavior : IEndpointBehavior
{
    private readonly Guid securityToken;

    public SecurityTokenEndpointBehavior(Guid securityToken)
    {
        this.securityToken = securityToken;
    }

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        clientRuntime.ClientMessageInspectors.Add(new SecurityTokenMessageInspector(securityToken));
    }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

    public void Validate(ServiceEndpoint endpoint) { }
}