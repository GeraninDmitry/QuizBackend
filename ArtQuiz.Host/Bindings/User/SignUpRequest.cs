using System.ComponentModel.DataAnnotations;
using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;

namespace ArtQuiz.Host.Bindings.User;

public class SignUpRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public LanguageTypeEnum Language { get; set; }
    
    [Required]
    public ApplicationTypeEnum ApplicationTypeEnum { get; set; }
    
}