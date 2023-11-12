using InetTech_Practice2.Parsers;
using InetTech_Practice2.Transformers;
using InetTech_Practice2.Utils;

namespace InetTech_Practice2;

public class Demo
{
    public static void XmlSerializerParserDemo(string xmlFilePath, string xsdFilePath)
    {
        Console.WriteLine("-------- XmlSerializerParser demo --------");

        var xmlSerializerParser = new XmlSerializerParser();
        var topics = xmlSerializerParser.LoadTopics(xmlFilePath, xsdFilePath);

        if (topics is not null)
        {
            Console.WriteLine($"Deserialization using XmlSerializer successful. Number of topics: {topics?.TopicsList?.Count}");
            /*Console.WriteLine(topics);*/

            var topicsXmlOutputFilePath = Constants.TOPICS_XML_SERIALIZER_OUTPUT_FILE_PATH;
            xmlSerializerParser.SaveTopics(topics, topicsXmlOutputFilePath, xsdFilePath);
        }
    }

    public static void XmlDocumentParserDemo(string xmlFilePath, string xsdFilePath)
    {
        Console.WriteLine("-------- XmlDocumentParser demo --------");

        var xmlDocumentParser = new XmlDocumentParser();
        var topics = xmlDocumentParser.LoadTopics(xmlFilePath, xsdFilePath);

        if (topics is not null)
        {
            Console.WriteLine($"Deserialization using XmlDocument successful. Number of topics: {topics?.TopicsList?.Count}");
            /*Console.WriteLine(topics);*/

            var topicsXmlOutputFilePath = Constants.TOPICS_XML_DOCUMENT_OUTPUT_FILE_PATH;
            xmlDocumentParser.SaveTopics(topics, topicsXmlOutputFilePath, xsdFilePath);
        }
    }

    public static void XmlReaderWriterParsersDemo(string xmlFilePath, string xsdFilePath)
    {
        Console.WriteLine("-------- XmlReaderParser demo --------");

        var xmlReaderParser = new XmlReaderParser();
        var topics = xmlReaderParser.LoadTopics(xmlFilePath, xsdFilePath);

        if (topics is not null)
        {
            Console.WriteLine($"Deserialization using XmlReader successful. Number of topics: {topics?.TopicsList?.Count}");
            /*Console.WriteLine(topics);*/

            Console.WriteLine("\n-------- XmlWriterParser demo --------");
            var topicsXmlOutputFilePath = Constants.TOPICS_XML_WRITER_OUTPUT_FILE_PATH;
            var xmlWriterParser = new XmlWriterParser();
            xmlWriterParser.SaveTopics(topics, topicsXmlOutputFilePath, xsdFilePath);
        }
    }

    public static void XsltTransformerDemo(string xmlFilePath, string xsltFilePath, string outputFilePath)
    {
        Console.WriteLine("-------- XsltTransfromer demo --------");

        var xsltTransformer = new XsltTransformer();
        xsltTransformer.TransformXmlToHtml(xmlFilePath, xsltFilePath, outputFilePath);
    }
}