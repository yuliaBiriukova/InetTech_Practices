using InetTech_Practice2.Classes;
using InetTech_Practice2.Entities.Enums;
using InetTech_Practice2.Utils;
using InetTech_Practice2.Validators;
using System.Xml;

namespace InetTech_Practice2.Parsers;

public class XmlReaderParser
{
    public Topics? LoadTopics(string xmlFilePath, string xsdFilePath)
    {
        if (XmlValidator.ValidateXmlAgainstXsd(xmlFilePath, xsdFilePath))
        {
            using (var reader = XmlReader.Create(xmlFilePath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == Constants.TOPICS_TAG)
                    {
                        var topics = ReadTopics(reader);
                        return topics;
                    }
                }
            }
        }
        return null;
    }

    private Topics ReadTopics(XmlReader reader)
    {
        var topics = new Topics();

        try
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == Constants.TOPIC_TAG)
                {
                    topics.TopicsList.Add(ReadTopic(reader));
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.TOPICS_TAG)
                {
                    // End of the topics element
                    break;
                }
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured during reading topics: {ex}");
        }

        return topics;
    }

    private Topic ReadTopic(XmlReader reader)
    {
        var topic = new Topic();

        try
        {
            topic.Id = int.Parse(reader.GetAttribute("id"));
            topic.Version = reader.GetAttribute("version");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case Constants.LEVEL_TAG:
                            topic.Level = ReadLevel(reader);
                            break;
                        case Constants.NAME_TAG:
                            topic.Name = reader.ReadElementContentAsString();
                            break;
                        case Constants.CONTENT_TAG:
                            topic.Content = reader.ReadElementContentAsString();
                            break;
                        case Constants.EXERCISES_TAG:
                            topic.Exercises = ReadExercises(reader);
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.TOPIC_TAG)
                {
                    // End of the topic element
                    break;
                }
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured during reading topic: {ex}");
        }

        return topic;
    }

    private Level ReadLevel(XmlReader reader)
    {
        var level = new Level();

        try
        {
            level.Id = int.Parse(reader.GetAttribute("id"));
            level.Version = reader.GetAttribute("version");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case Constants.CODE_TAG:
                            level.Code = reader.ReadElementContentAsString();
                            break;
                        case Constants.NAME_TAG:
                            level.Name = reader.ReadElementContentAsString();
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.LEVEL_TAG)
                {
                    // End of the level element
                    break;
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error occured during reading level: {ex}");
        }

        return level;
    }

    private List<Exercise> ReadExercises(XmlReader reader)
    {
        var exercises = new List<Exercise>();

        try
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == Constants.EXERCISE_TAG)
                {
                    exercises.Add(ReadExercise(reader));
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.EXERCISES_TAG)
                {
                    // End of the exercises element
                    break;
                }
            }
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Error occured during reading exercises: {ex}");
        }

        return exercises;
    }

    private Exercise ReadExercise(XmlReader reader)
    {
        var exercise = new Exercise();

        try
        {
            exercise.Id = Convert.ToInt32(reader.GetAttribute("id"));
            exercise.Version = reader.GetAttribute("version");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case Constants.TOPIC_ID_TAG:
                            exercise.TopicId = Convert.ToInt32(reader.ReadElementContentAsString());
                            break;
                        case Constants.TYPE_TAG:
                            exercise.Type = MapExerciseType(reader.ReadElementContentAsString()); ;
                            break;
                        case Constants.TASK_TAG:
                            exercise.Task = reader.ReadElementContentAsString();
                            break;
                        case Constants.ANSWER_TAG:
                            exercise.Answer = reader.ReadElementContentAsString();
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.EXERCISE_TAG)
                {
                    // End of the exercise element
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured during reading exercise: {ex}");
        }

        return exercise;
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
}