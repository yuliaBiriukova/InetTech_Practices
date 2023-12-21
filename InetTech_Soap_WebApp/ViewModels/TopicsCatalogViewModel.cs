using InetTech_SoapClient.TopicService;

namespace InetTech_Soap_WebApp.ViewModels
{
    public class TopicsCatalogViewModel
    {
        public IEnumerable<Level> Levels {  get; set; }
        public Level? Level { get; set; }
        public IEnumerable<Topic>? Topics { get; set; }
    }
}