﻿using InetTech_SoapService.Entities.Enums;
using InetTech_SoapService.Utils;
using System.Runtime.Serialization;

namespace InetTech_SoapService.Entities;

[DataContract(Namespace = Constants.TOPIC_NAMESPACE)]
public class Exercise : Entity
{
    [DataMember(IsRequired = true, Name = "topicId")]
    public int TopicId { get; set; }

    [DataMember(IsRequired = true, Name = "type")]
    public ExerciseType Type { get; set; }

    [DataMember(IsRequired = true, Name = "task")]
    public string Task { get; set; }

    [DataMember(IsRequired = true, Name = "answer")]
    public string Answer { get; set; }

    public override string? ToString()
    {
        return $"Exercise #{Id} {Type}\n" +
            $"Topic: #{TopicId}\n" +
            $"Task: {Task}\n" +
            $"Answer: {Answer}\n";
    }
}