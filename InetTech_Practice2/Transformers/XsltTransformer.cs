﻿using System.Xml.Xsl;
using System.Xml;

namespace InetTech_Practice2.Transformers;

public class XsltTransformer
{
    public void TransformXmlToHtml(string xmlFilePath, string xsltFilePath, string outputFilePath)
    {
        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            var xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            using (var writer = new StringWriter())
            {
                xslt.Transform(xmlDoc, null, writer);
                File.WriteAllText(outputFilePath, writer.ToString());
                Console.WriteLine($"Data from {xmlFilePath} file is transformed to file {outputFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occured during XML transformation to HTML: " + ex);
        }
    }
}