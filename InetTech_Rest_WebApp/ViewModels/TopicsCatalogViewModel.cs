using InetTech_RestClient.Clients;

namespace InetTech_Rest_WebApp.ViewModels
{
    public class TopicsCatalogViewModel
    {
        public IEnumerable<Level> Levels {  get; set; }
        public Level? Level { get; set; }
        public IEnumerable<Topic>? Topics { get; set; }
    }
}