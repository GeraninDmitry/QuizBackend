using System.ComponentModel.DataAnnotations;
using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;

namespace ArtQuiz.Host.Bindings.User;

public class SendVerificationCodeRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public LanguageTypeEnum Language { get; set; }
    
    [Required]
    public ApplicationTypeEnum ApplicationTypeEnum { get; set; }
}