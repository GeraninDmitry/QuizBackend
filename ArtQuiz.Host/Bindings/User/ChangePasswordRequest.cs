using System.ComponentModel.DataAnnotations;

namespace ArtQuiz.Host.Bindings.User;

public class ChangePasswordRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string VerificationCode { get; set; }

    [Required] 
    public string NewPassword { get; set; }
}