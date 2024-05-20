using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class QuizRespectModel
{
    public Guid QuizRespectId { get; private set; }
    public Guid QuizId { get; private set; }
    public string UserId { get; private set; }

    public bool IsLiked { get; private set; }
    public bool IsDisliked { get; private set; }

    public DateTime CreatedOn { get; private set; }
    
    public IdentityUser User { get; private set; }
    public QuizModel Quiz { get; private set; }
}