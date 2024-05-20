using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class QuizModel
{
    public Guid QuizId { get; private set; }
    public string UserId { get; private set; }

    public QuizType.QuizTypeEnum Type { get; private set; }
    public QuizTheme.QuizThemeEnum Theme { get; private set; }
    public QuizStatus.QuizStatusEnum Status { get; private set; }
    public ApplicationTypeEnum Application { get; private set; }
    public LanguageTypeEnum Language { get; private set; }

    public string? Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public IdentityUser User { get; private set; }
    public IEnumerable<QuizTagModel> Tags { get; set; }
}