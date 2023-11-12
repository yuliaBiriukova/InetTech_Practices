using InetTech_Practice2.Classes;
using InetTech_Practice2.Entities.Enums;
using InetTech_Practice2.Utils;
using InetTech_Practice2.Validators;
using System.Reflection.Emit;
using System.Xml;

namespace InetTech_Practice2.Parsers;

public class XmlDocumentParser
{
    public Topics? LoadTopics(string xmlFilePath, string xsdFilePath)
    {
        if (XmlValidator.ValidateXmlAgainstXsd(xmlFilePath, xsdFilePath))
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            var topics = DeserializeTopics(xmlDoc);
            return topics;
        }
        return null;
    }

    private Topics? DeserializeTopics(XmlDocument xmlDoc)
    {
        try
        {
            var topics = new List<Topic>();
            var topicsElement = xmlDoc.DocumentElement;
            if (topicsElement is not null)
            {
                foreach (XmlElement topicElement in topicsElement)
                {
                    var topic = DeserializeTopic(topicElement);
                    if (topic is not null)
                    {
                        topics.Add(topic);
                    }
                }
                return new Topics(topics);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Topics deserialization failed with error: {ex.Message}");
        }
        return null;
    }

    private Topic? DeserializeTopic(XmlElement topicElement)
    {
        try
        {
            var topic = new Topic();

            var id = topicElement.Attributes.GetNamedItem(Constants.ID_ATTRIBUTE);
            if (id is not null)
            {
                topic.Id = int.Parse(id.InnerText);
            }

            var version = topicElement.Attributes.GetNamedItem(Constants.VERSION_ATTRIBUTE);
            if (version is not null)
            {
                topic.Version = version.InnerText;
            }

            foreach (XmlNode childnode in topicElement.ChildNodes)
            {
                if (childnode.Name == Constants.NAME_TAG)
                {
                    topic.Name = childnode.InnerText;
                } 
                else if (childnode.Name == Constants.CONTENT_TAG)
                {
                    topic.Content = childnode.InnerText;
                }
                else if (childnode.Name == Constants.LEVEL_TAG)
                {
                    var level = DeserializeLevel(childnode);
                    if(level is not null)
                    {
                        topic.Level = level;
                    }
                }
                else if (childnode.Name == Constants.EXERCISES_TAG)
                {
                    topic.Exercises = new List<Exercise>();
                    foreach (XmlNode exerciseNode in childnode)
                    {
                        var exercise = DeserializeExercise(exerciseNode);
                        if(exercise is not null)
                        {
                            topic.Exercises.Add(exercise);
                        }
                    }
                }
            }

            return topic;
        } catch(Exception ex) 
        {
            Console.WriteLine($"Topic deserialization failed with error: {ex}");
        }

        return null;
    }

    private Level? DeserializeLevel(XmlNode levelNode)
    {
        try
        {
            var level = new Level();

            var id = levelNode?.Attributes?.GetNamedItem(Constants.ID_ATTRIBUTE);
            if (id is not null)
            {
                level.Id = int.Parse(id.InnerText);
            }
            
            var version = levelNode?.Attributes?.GetNamedItem(Constants.VERSION_ATTRIBUTE);
            if (version is not null)
            {
                level.Version = version.InnerText;
            }

            foreach (XmlNode childnode in levelNode.ChildNodes)
            {
                if (childnode.Name == Constants.NAME_TAG)
                {
                    level.Name = childnode.InnerText;
                }
                else if (childnode.Name == Constants.CODE_TAG)
                {
                    level.Code = childnode.InnerText;
                }
            }

            return level;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Level deserialization failed with error: {ex}");
        }
        return null;
    }

    private Exercise? DeserializeExercise(XmlNode exerciseNode)
    {
        try
        {
            var exercise = new Exercise();

            var id = exerciseNode?.Attributes?.GetNamedItem(Constants.ID_ATTRIBUTE);
            if (id is not null)
            {
                exercise.Id = int.Parse(id.InnerText);
            }

            var version = exerciseNode?.Attributes?.GetNamedItem(Constants.VERSION_ATTRIBUTE);
            if (version is not null)
            {
                exercise.Version = version.InnerText;
            }

            foreach (XmlNode childnode in exerciseNode.ChildNodes)
            {
                if (childnode.Name == Constants.TOPIC_ID_TAG)
                {
                    exercise.TopicId = int.Parse(childnode.InnerText);
                }
                else if (childnode.Name == Constants.TYPE_TAG)
                {
                    string typeString = childnode.InnerText;
                    ExerciseType type = MapExerciseType(typeString);
                    exercise.Type = type;
                }
                else if (childnode.Name == Constants.TASK_TAG)
                {
                    exercise.Task = childnode.InnerText;
                }
                else if (childnode.Name == Constants.ANSWER_TAG)
                {
                    exercise.Answer = childnode.InnerText;
                }
            }
            
            return exercise;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exercise deserialization failed with error: {ex}");
        }
        return null;
    }

    private ExerciseType MapExerciseType(string xmlExerciseTypeValue)
    {
        switch (xmlExerciseTypeValue)
        {
            case "Translation":
                return ExerciseType.Translation;
            case "True/false":
                return ExerciseType.TrueFalse;
            case "Correct the mistake":
                return ExerciseType.CorrectTheMistake;
            default:
                throw new InvalidOperationException($"Unexpected ExerciseType value: {xmlExerciseTypeValue}");
        }
    }

    public void SaveTopics(Topics topics, string xmlOutputFilePath, string xsdFilePath)
    {   
        try
        {
            var xmlDoc = SerializeTopics(topics);
            xmlDoc.Save(xmlOutputFilePath);
            Console.WriteLine($"Topics were serialized using XmlDocument and saved to {xmlOutputFilePath}.");
            XmlValidator.ValidateXmlAgainstXsd(xmlOutputFilePath, xsdFilePath);
        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error occured during saving topics to xml file: {ex}");
        }  
    }

    private XmlDocument SerializeTopics(Topics topics)
    {
        var xmlDoc = new XmlDocument();

        var xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
        xmlDoc.AppendChild(xmlDeclaration);

        var topicsElement = xmlDoc.CreateElement(Constants.TOPICS_TAG, Constants.TOPICS_NAMESPACE);
        xmlDoc.AppendChild(topicsElement);

        foreach (var topic in topics.TopicsList)
        {
            var topicElement = SerializeTopic(xmlDoc, topic);
            topicsElement.AppendChild(topicElement);
        }

        return xmlDoc;
    }

    private XmlElement SerializeTopic(XmlDocument xmlDoc, Topic topic)
    {
        var topicElement = xmlDoc.CreateElement(Constants.TOPIC_TAG, Constants.TOPICS_NAMESPACE);
        topicElement.SetAttribute(Constants.ID_ATTRIBUTE, topic.Id.ToString());
        if(topic.Version is not null)
        {
            topicElement.SetAttribute(Constants.VERSION_ATTRIBUTE, topic.Version);
        }

        var levelElement = SerializeLevel(xmlDoc, topic.Level);
        topicElement.AppendChild(levelElement);

        var nameElementTopic = xmlDoc.CreateElement(Constants.NAME_TAG, Constants.TOPICS_NAMESPACE);
        nameElementTopic.InnerText = topic.Name;
        topicElement.AppendChild(nameElementTopic);

        var contentElement = xmlDoc.CreateElement(Constants.CONTENT_TAG, Constants.TOPICS_NAMESPACE);
        contentElement.InnerText = topic.Content;
        topicElement.AppendChild(contentElement);

        var exercisesElement = xmlDoc.CreateElement(Constants.EXERCISES_TAG, Constants.TOPICS_NAMESPACE);
        foreach (var exercise in topic.Exercises)
        {
            var exerciseElement = SerializeExercise(xmlDoc, exercise);
            exercisesElement.AppendChild(exerciseElement);
        }
        topicElement.AppendChild(exercisesElement);

        return topicElement;
    }

    private XmlElement SerializeLevel(XmlDocument xmlDoc, Level level)
    {
        var levelElement = xmlDoc.CreateElement(Constants.LEVEL_TAG, Constants.TOPICS_NAMESPACE);
        levelElement.SetAttribute(Constants.ID_ATTRIBUTE, level.Id.ToString());

        if(level.Version is not null)
        {
            levelElement.SetAttribute(Constants.VERSION_ATTRIBUTE, level.Version);
        }

        var codeElement = xmlDoc.CreateElement(Constants.CODE_TAG, Constants.TOPICS_NAMESPACE);
        codeElement.InnerText = level.Code;
        levelElement.AppendChild(codeElement);

        var nameElement = xmlDoc.CreateElement(Constants.NAME_TAG, Constants.TOPICS_NAMESPACE);
        nameElement.InnerText = level.Name;
        levelElement.AppendChild(nameElement);

        return levelElement;
    }

    private XmlElement SerializeExercise(XmlDocument xmlDoc, Exercise exercise)
    {
        var exerciseElement = xmlDoc.CreateElement(Constants.EXERCISE_TAG, Constants.TOPICS_NAMESPACE);
        exerciseElement.SetAttribute(Constants.ID_ATTRIBUTE, exercise.Id.ToString());

        if (exercise.Version is not null)
        {
            exerciseElement.SetAttribute(Constants.VERSION_ATTRIBUTE, exercise.Version.ToString());
        }

        var topicIdElement = xmlDoc.CreateElement(Constants.TOPIC_ID_TAG, Constants.TOPICS_NAMESPACE);
        topicIdElement.InnerText = exercise.TopicId.ToString();
        exerciseElement.AppendChild(topicIdElement);

        var typeElement = xmlDoc.CreateElement(Constants.TYPE_TAG, Constants.TOPICS_NAMESPACE);
        typeElement.InnerText = ExerciseTypeToString(exercise.Type);
        exerciseElement.AppendChild(typeElement);

        var taskElement = xmlDoc.CreateElement(Constants.TASK_TAG, Constants.TOPICS_NAMESPACE);
        taskElement.InnerText = exercise.Task;
        exerciseElement.AppendChild(taskElement);

        var answerElement = xmlDoc.CreateElement(Constants.ANSWER_TAG, Constants.TOPICS_NAMESPACE);
        answerElement.InnerText = exercise.Answer;
        exerciseElement.AppendChild(answerElement);

        return exerciseElement;
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
