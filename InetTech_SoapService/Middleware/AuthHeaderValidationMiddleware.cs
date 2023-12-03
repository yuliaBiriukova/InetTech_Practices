using InetTech_SoapService.Const;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace InetTech_SoapService.Middleware
{
    public class AuthHeaderValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthHeaderValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.Equals(context.Request.Method, "GET", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var soapEnvelope = await ReadRequestBody(context.Request);
            var authHeader = ExtractAuthorizationHeader(soapEnvelope);

            if (string.IsNullOrEmpty(authHeader))
            {
                context.Response.ContentType = "text/xml";
                var faultReason = "Authorization header is missing.";
                var xml = CreateSoapFaultXml(faultReason);
                await context.Response.WriteAsync(xml);   
                return;
            }

            await _next(context);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            var body = request.Body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await body.ReadAsync(buffer, 0, buffer.Length);
            string requestBody = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            return requestBody;
        }

        public static string ExtractAuthorizationHeader(string soapEnvelope)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(soapEnvelope);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("s", Constants.ENVELOPE_NAMESPACE);
            nsmgr.AddNamespace("auth", Constants.TOPIC_NAMESPACE);

            XmlNode authNode = xmlDoc.SelectSingleNode("//s:Header/auth:Authorization", nsmgr);
            if (authNode != null)
            {
                return authNode.InnerText;
            }

            return string.Empty;
        }

        public string CreateSoapFaultXml(string faultReason)
        {
            XNamespace s = Constants.ENVELOPE_NAMESPACE;
            XNamespace xsi = Constants.XSI_NAMESPACE;
            XNamespace xsd = Constants.XSD_NAMESPACE;
            XNamespace faultNamespace = Constants.FAULT_NAMESPACE;

            var envelope = new XElement(s + "Envelope",
                new XAttribute(XNamespace.Xmlns + "s", s),
                new XAttribute(XNamespace.Xmlns + "xsd", xsd),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                new XElement(s + "Body",
                    new XElement(s + "Fault",
                        new XElement("faultcode", "s:AuthorizationMissing"),
                        new XElement("faultstring", faultReason)
                    )
                )
            );

            return envelope.ToString();
        }
    }
}