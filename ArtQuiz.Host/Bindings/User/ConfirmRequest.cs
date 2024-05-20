using System.ComponentModel.DataAnnotations;

namespace ArtQuiz.Host.Bindings.User;

public class ConfirmRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string VerificationCode { get; set; }
}