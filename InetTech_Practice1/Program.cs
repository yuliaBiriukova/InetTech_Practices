using InetTech_Practice1;

Console.WriteLine("XML validation against XSD:");
Console.Write("Validating levels: ");
XmlValidator.ValidateLevels();

Console.Write("Validating topics: ");
XmlValidator.ValidateTopics();

Console.Write("Validating exercises: ");
XmlValidator.ValidateExercises();

Console.Write("Validating completed topics: ");
XmlValidator.ValidateCompletedTopics();

Console.WriteLine("\nTransforming XML to HTML using XSLT:");

var levelsXmlFilePath = "xml/levels/levels.xml";
var levelsXsltFilePath = "xslt/levels.xslt";
var levelsHtmlFilePath = "levels.html";

XsltTransformer.TransformXmlToHtml(levelsXmlFilePath, levelsXsltFilePath, levelsHtmlFilePath);

var exercisesXmlFilePath = "xml/exercises/exercises.xml";
var exercisesXsltFilePath = "xslt/exercises.xslt";
var exercisesHtmlFilePath = "exercises.html";

XsltTransformer.TransformXmlToHtml(exercisesXmlFilePath, exercisesXsltFilePath, exercisesHtmlFilePath);