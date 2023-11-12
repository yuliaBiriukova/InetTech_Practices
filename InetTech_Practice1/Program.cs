using InetTech_Practice1;

Console.WriteLine("XML validation against XSD:");
Console.Write("Validating levels: ");
XmlValidator.ValidateLevels();

Console.Write("Validating topics: ");
XmlValidator.ValidateTopics();

Console.Write("Validating exercises: ");
XmlValidator.ValidateExercises();

Console.WriteLine("\nTransforming XML to HTML using XSLT:");

var levelsXmlFilePath = "static/xml/levels/levels.xml";
var levelsXsltFilePath = "static/xslt/levels.xslt";
var levelsHtmlFilePath = "static/html/levels.html";

XsltTransformer.TransformXmlToHtml(levelsXmlFilePath, levelsXsltFilePath, levelsHtmlFilePath);

var exercisesXmlFilePath = "static/xml/exercises/exercises.xml";
var exercisesXsltFilePath = "static/xslt/exercises.xslt";
var exercisesHtmlFilePath = "static/html/exercises.html";

XsltTransformer.TransformXmlToHtml(exercisesXmlFilePath, exercisesXsltFilePath, exercisesHtmlFilePath);