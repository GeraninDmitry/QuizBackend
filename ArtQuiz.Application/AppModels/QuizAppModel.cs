using ArtQuiz.Domain.Quiz;

namespace ArtQuiz.Application.AppModels;

public class QuizAppModel
{
    public Guid QuizId { get; set; }
    public QuizType.QuizTypeEnum Type { get; set; }
    public QuizTheme.QuizThemeEnum Theme { get; set; }
    public QuizStatus.QuizStatusEnum Status { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; }
    public string? Text { get; set; }
}