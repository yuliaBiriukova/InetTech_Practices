using System.Xml.Schema;
using System.Xml;

namespace InetTech_Practice1;

public class Validator
{
    public static void ValidateLevels()
    {
        var levelsXmlFilePath = "xml/levels/levels.xml";
        var levelsXsdFilePath = "xml/levels/levels.xsd";
        var entityXsdFilePath = "xml/entity/entity.xsd";

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
            settings.Schemas.Add(null, levelsXsdFilePath);
            settings.Schemas.Add(null, entityXsdFilePath);

            xmlReader = XmlReader.Create(levelsXmlFilePath, settings);

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

    public static void ValidateTopics()
    {
        var topicsXmlFilePath = "xml/topics/topics.xml";
        var topicsXsdFilePath = "xml/topics/topics.xsd";
        var entityXsdFilePath = "xml/entity/entity.xsd";

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
            settings.Schemas.Add(null, topicsXsdFilePath);
            settings.Schemas.Add(null, entityXsdFilePath);

            xmlReader = XmlReader.Create(topicsXmlFilePath, settings);

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

    public static void ValidateExercises()
    {
        var exercisesXmlFilePath = "xml/exercises/exercises.xml";
        var exercisesXsdFilePath = "xml/exercises/exercises.xsd";
        var entityXsdFilePath = "xml/entity/entity.xsd";

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
            settings.Schemas.Add(null, exercisesXsdFilePath);
            settings.Schemas.Add(null, entityXsdFilePath);

            xmlReader = XmlReader.Create(exercisesXmlFilePath, settings);

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