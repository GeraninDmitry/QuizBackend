using ArtQuiz.Domain.QuizMark;

namespace ArtQuiz.Host.Bindings.Quiz;

public class AddQuizMarkRequest
{
    public Guid QuizId { get; set; }
    public QuizMarkType.QuizMarkTypeEnum Type { get; set; }
    public bool IsActive { get; set; }
}