using InetTech_RestService.Const;
using System.Xml.Serialization;

namespace InetTech_RestService.Entities.Enums;

[Serializable]
[XmlType(Namespace = Constants.TOPIC_NAMESPACE)]
public enum ExerciseType
{
    Translation,
    [XmlEnum("True/false")]
    TrueFalse,
    [XmlEnum("Correct the mistake")]
    CorrectTheMistake,
}