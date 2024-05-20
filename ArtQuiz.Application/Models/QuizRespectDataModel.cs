namespace ArtQuiz.Application.Models;

public class QuizRespectDataModel
{
    public Guid QuizId { get; private set; }
    public int LikedCount { get; private set; }
    public int DislikedCount { get; private set; }
}