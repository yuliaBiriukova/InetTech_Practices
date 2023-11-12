using InetTech_Practice2.Classes;
using InetTech_Practice2.Entities.Enums;
using InetTech_Practice2.Utils;
using InetTech_Practice2.Validators;
using System.Xml;

namespace InetTech_Practice2.Parsers;

public class XmlWriterParser
{
    public void SaveTopics(Topics topics, string xmlOutputFilePath, string xsdFilePath)
    {
        try
        {
            using (XmlWriter writer = XmlWriter.Create(xmlOutputFilePath))
            {
                WriteTopics(writer, topics);
            }
            Console.WriteLine($"Topics were serialized using XmlWriter and saved to {xmlOutputFilePath}.");
            XmlValidator.ValidateXmlAgainstXsd(xmlOutputFilePath, xsdFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured during saving topics to xml file: {ex}");
        }
    }

    private void WriteTopics(XmlWriter writer, Topics topics)
    {
        writer.WriteStartDocument();
        writer.WriteStartElement(Constants.TOPICS_TAG, Constants.TOPICS_NAMESPACE);

        foreach (var topic in topics.TopicsList)
        {
            WriteTopic(writer, topic);
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();
    }

    private void WriteTopic(XmlWriter writer, Topic topic)
    {
        writer.WriteStartElement(Constants.TOPIC_TAG);
        writer.WriteAttributeString(Constants.ID_ATTRIBUTE, topic.Id.ToString());
        if(!string.IsNullOrEmpty(topic.Version)) 
        {
            writer.WriteAttributeString(Constants.VERSION_ATTRIBUTE, topic.Version);
        }

        WriteLevel(writer, topic.Level);

        writer.WriteElementString(Constants.NAME_TAG, topic.Name);
        writer.WriteElementString(Constants.CONTENT_TAG, topic.Content);

        writer.WriteStartElement(Constants.EXERCISES_TAG);
        foreach (var exercise in topic.Exercises)
        {
            WriteExercise(writer, exercise);
        }
        writer.WriteEndElement();

        writer.WriteEndElement();
    }

    private void WriteLevel(XmlWriter writer, Level level)
    {
        writer.WriteStartElement(Constants.LEVEL_TAG);
        writer.WriteAttributeString(Constants.ID_ATTRIBUTE, level.Id.ToString());

        if(!string.IsNullOrEmpty(level.Version))
        {
            writer.WriteAttributeString(Constants.VERSION_ATTRIBUTE, level.Version);
        }

        writer.WriteElementString(Constants.CODE_TAG, level.Code);
        writer.WriteElementString(Constants.NAME_TAG, level.Name);

        writer.WriteEndElement();
    }

    private void WriteExercise(XmlWriter writer, Exercise exercise)
    {
        writer.WriteStartElement(Constants.EXERCISE_TAG);
        writer.WriteAttributeString(Constants.ID_ATTRIBUTE, exercise.Id.ToString());

        if (!string.IsNullOrEmpty(exercise.Version))
        {
            writer.WriteAttributeString(Constants.VERSION_ATTRIBUTE, exercise.Version);
        }

        writer.WriteElementString(Constants.TOPIC_ID_TAG, exercise.TopicId.ToString());
        writer.WriteElementString(Constants.TYPE_TAG, ExerciseTypeToString(exercise.Type));
        writer.WriteElementString(Constants.TASK_TAG, exercise.Task);
        writer.WriteElementString(Constants.ANSWER_TAG, exercise.Answer);

        writer.WriteEndElement();
    }

    private string ExerciseTypeToString(ExerciseType type)
    {
        switch (type)
        {
            case ExerciseType.Translation:
                return "Translation";
            case ExerciseType.TrueFalse:
                return "True/false";
            case ExerciseType.CorrectTheMistake:
                return "Correct the mistake";
            default:
                throw new InvalidOperationException($"Unexpected ExerciseType value: {type}");
        }
    }
}
