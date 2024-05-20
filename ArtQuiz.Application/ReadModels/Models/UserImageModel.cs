using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class UserImageModel
{
    public Guid UserImageId { get; set; }
    public string UserId { get; set; }
    public string? Image { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public IdentityUser User { get; private set; }
}