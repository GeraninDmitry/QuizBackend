namespace ArtQuiz.Host.Bindings.Quiz;

public class AddQuizRespectRequest
{
    public Guid QuizId { get; set; }
    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }
}