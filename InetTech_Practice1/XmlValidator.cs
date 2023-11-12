using System.Xml.Schema;
using System.Xml;

namespace InetTech_Practice1;

internal class XmlValidator
{
    public static void ValidateLevels()
    {
        var levelsXmlFilePath = "static/xml/levels/levels.xml";
        var levelsXsdFilePath = "static/xml/levels/levels.xsd";

        ValidateXml(levelsXmlFilePath, levelsXsdFilePath);
    }

    public static void ValidateTopics()
    {
        var topicsXmlFilePath = "static/xml/topics/topics.xml";
        var topicsXsdFilePath = "static/xml/topics/topics.xsd";

        ValidateXml(topicsXmlFilePath, topicsXsdFilePath);
    }

    public static void ValidateExercises()
    {
        var exercisesXmlFilePath = "static/xml/exercises/exercises.xml";
        var exercisesXsdFilePath = "static/xml/exercises/exercises.xsd";

        ValidateXml(exercisesXmlFilePath, exercisesXsdFilePath);
    }

    private static void ValidateXml(string xmlFilePath, string xsdFilePath)
    {
        var entityXsdFilePath = "static/xml/entity/entity.xsd";

        XmlReader xmlReader = null;

        try
        {
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(HandleValidaton);
            settings.XmlResolver = new XmlUrlResolver();
            settings.Schemas.Add(null, xsdFilePath);
            settings.Schemas.Add(null, entityXsdFilePath);

            xmlReader = XmlReader.Create(xmlFilePath, settings);

            while (xmlReader.Read()) { }

            Console.WriteLine("Validation succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }
        finally
        {
            if (xmlReader is not null)
            {
                xmlReader.Close();
            }
        }
    }

    private static void HandleValidaton(object senderm, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Error)
        {
            Console.WriteLine($"Validation Error: {e.Message}");
        }
        else if (e.Severity == XmlSeverityType.Warning)
        {
            Console.WriteLine($"Validation Warning: {e.Message}");
        }
    }
}