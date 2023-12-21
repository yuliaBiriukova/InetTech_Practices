using InetTech_RestClient.Clients;

namespace InetTech_Rest_WebApp.ViewModels
{
    public class TopicUpdateViewModel : TopicAddViewModel
    {
        public int Id { get; set; }

        public List<Exercise>? Exercises { get; set; }
    }
}