using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.QuizMark;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class QuizMarkModel
{
    public Guid QuizMarkId { get; private set; }
    public Guid QuizId { get; private set; }
    public string UserId { get; private set; }
    
    public QuizMarkType.QuizMarkTypeEnum Type { get; private set; }
    public bool IsActive { get; private set; }
    
    public DateTime CreatedOn { get; private set; }
    
    public IdentityUser User { get; private set; }
    public QuizModel Quiz { get; private set; }
}