using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;

namespace ArtQuiz.Application.Models;

public class QuizDataModel
{
    public Guid QuizId { get; private set; }
    public string UserId { get; private set; }
    public string UserName { get; private set; }
    public QuizType.QuizTypeEnum Type { get; private set; }
    public QuizTheme.QuizThemeEnum Theme { get; private set; }
    public ApplicationTypeEnum Application { get; private set; }
    public QuizStatus.QuizStatusEnum Status { get; private set; }
    public string Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }
}