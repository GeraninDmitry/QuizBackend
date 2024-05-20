using System.ComponentModel.DataAnnotations;

namespace ArtQuiz.Host.Bindings.User;

public class AddUserAvatarRequest
{
    [Required]
    public string Image { get; set; }
    
    [Required]
    public string ImageType { get; set; }
}