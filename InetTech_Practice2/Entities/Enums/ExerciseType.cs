using System.Xml.Serialization;

namespace InetTech_Practice2.Entities.Enums;

[Serializable]
[XmlType(Namespace = "http://eng.grammar/entity/topic")]
public enum ExerciseType
{
    Translation,
    [XmlEnum("True/false")]
    TrueFalse,
    [XmlEnum("Correct the mistake")]
    CorrectTheMistake,
}