using InetTech_Practice2;
using InetTech_Practice2.Transformers;
using InetTech_Practice2.Utils;

var topicsXmlFilePath = Constants.TOPICS_XML_FILE_PATH;
var topicsXsdFilePath = Constants.TOPICS_XSD_FILE_PATH;

/*Demo.XmlSerializerParserDemo(topicsXmlFilePath, topicsXsdFilePath);

Console.WriteLine();

Demo.XmlDocumentParserDemo(topicsXmlFilePath, topicsXsdFilePath);

Console.WriteLine();

Demo.XmlReaderWriterParsersDemo(topicsXmlFilePath, topicsXsdFilePath);*/

XsltTransformer.TransformXmlToHtml(topicsXmlFilePath, Constants.TOPICS_XSLT_FILE_PATH, Constants.TOPICS_HTML_FILE_PATH);