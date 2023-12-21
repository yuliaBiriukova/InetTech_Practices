using InetTech_RestClient.Clients;
using System.ComponentModel.DataAnnotations;

namespace InetTech_Rest_WebApp.ViewModels;

public class TopicAddViewModel
{
    [Required(ErrorMessage = "Required field")]
    [Range(1, int.MaxValue)]
    public int LevelId { get; set; }

    [Required(ErrorMessage = "Required field")]
    [MinLength(1)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Required field")]
    [MinLength(1)]
    public string Content { get; set; }
}