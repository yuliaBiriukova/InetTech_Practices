using InetTech_SoapClient.TopicService;

namespace InetTech_Soap_WebApp.ViewModels
{
    public class TopicUpdateViewModel : TopicAddViewModel
    {
        public int Id { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}