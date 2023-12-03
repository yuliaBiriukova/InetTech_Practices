using InetTech_SoapClient.Behaviors;
using InetTech_SoapClient.Helpers;
using ProfileService;
using System.ServiceModel;
using TopicService;

/*using (var client = new ProfileServiceClient())
{
    try
    {
        var profile = await client.GetProfileAsync(1);
        if (profile != null)
        {
            Console.WriteLine($"First Name: {profile.FirstName}");
            Console.WriteLine($"Last Name: {profile.LastName}");
            Console.WriteLine($"Email Address: {profile.Email}");
            Console.WriteLine($"Home Address: {profile.HomeAddress}");
        }
    }
    catch (FaultException<MissingProfileFault> ex)
    {
        Console.WriteLine($"Fault reason: {ex.Reason.ToString()}, fault code: {ex.Code.Name}, detail: {ex.Detail.Message}");
    }
    catch (FaultException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}*/

using (var client = new TopicServiceClient())
{
    try
    {
        var securityToken = Guid.Empty;
        var endpointBehavior = new SecurityTokenEndpointBehavior(securityToken);

        client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

        var topics = await client.GetTopicsByLevelIdAsync(1);
        if (topics != null)
        {
            Console.WriteLine($"Topics amount: {topics.Length}");
        }
    }
    catch (FaultException ex)
    {
        Console.WriteLine($"Fault reason: {ex.Reason}, fault code: {ex.Code.Name}, detail: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}