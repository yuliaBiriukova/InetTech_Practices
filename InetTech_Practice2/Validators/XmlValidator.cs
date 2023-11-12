using System.Xml.Schema;
using System.Xml;

namespace InetTech_Practice2.Validators;

public class XmlValidator
{
    public static bool ValidateXmlAgainstXsd(string xmlFilePath, string xsdFilePath)
    {
        try
        {
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.XmlResolver = new XmlUrlResolver();
            settings.Schemas.Add(null, xsdFilePath);

            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                while (reader.Read()) { }
            }

            Console.WriteLine($"{xmlFilePath} validation successful.");
            return true;
        }
        catch (XmlSchemaValidationException ex)
        {
            Console.WriteLine($"Validation of {xmlFilePath} failed with error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during validation of {xmlFilePath}: {ex.Message}");
            return false;
        }
    }
}