using System.Xml.Serialization;
using InetTech_Practice2.Validators;

namespace InetTech_Practice2.Parsers;

public class XmlSerializerParser
{
    public Topics? LoadTopics(string xmlFilePath, string xsdFilePath)
    {
        if (XmlValidator.ValidateXmlAgainstXsd(xmlFilePath, xsdFilePath))
        {
            var topics = DeserializeXml<Topics>(xmlFilePath);
            return topics;
        }
        return null;
    }

    public void SaveTopics(Topics topics, string xmlOutputFilePath, string xsdFilePath)
    {
        try
        {
            var isSerialized = Serialize(topics, xmlOutputFilePath);
            if(isSerialized)
            {
                Console.WriteLine($"Topics were serialized using XmlSerializer and saved to {xmlOutputFilePath}.");
                XmlValidator.ValidateXmlAgainstXsd(xmlOutputFilePath, xsdFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured during saving topics to xml file: {ex}");
        }
    }

    private T? DeserializeXml<T>(string xmlFilePath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var deserializedObjects = serializer.Deserialize(fileStream);
                if (deserializedObjects is not null)
                {
                    return (T)deserializedObjects;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deserialization using XmlSerializer failed with error: {ex}");
        }

        return default;
    }

    private bool Serialize<T>(T obj, string xmlOutputfilePath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fileStream = new FileStream(xmlOutputfilePath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, obj);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Serialization using XmlSerializer failded with error: {ex}");
            return false;
        }
    }
}