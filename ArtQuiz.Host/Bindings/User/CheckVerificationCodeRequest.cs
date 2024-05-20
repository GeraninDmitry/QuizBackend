using System.ComponentModel.DataAnnotations;

namespace ArtQuiz.Host.Bindings.User;

public class CheckVerificationCodeRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string VerificationCode { get; set; }
}