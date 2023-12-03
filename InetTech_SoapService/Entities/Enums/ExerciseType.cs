using InetTech_SoapService.Const;
using System.Runtime.Serialization;

namespace InetTech_SoapService.Entities.Enums;

[DataContract(Namespace = Constants.TOPIC_NAMESPACE)]
public enum ExerciseType
{
    [EnumMember]
    Translation,
    [EnumMember]
    TrueFalse,
    [EnumMember]
    CorrectTheMistake,
}