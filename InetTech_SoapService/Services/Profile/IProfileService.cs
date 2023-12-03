using InetTech_SoapService.Entities;
using InetTech_SoapService.Faults;
using System.ServiceModel;

namespace InetTech_SoapService.Services;

[ServiceContract]
public interface IProfileService
{
    [OperationContract]
    [FaultContract(typeof(TopicsEmptyFault))]
    Profile GetProfile(int profileId);
}