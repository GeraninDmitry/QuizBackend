using System.ComponentModel.DataAnnotations;

namespace ArtQuiz.Host.Bindings.User;

public class LogInRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}