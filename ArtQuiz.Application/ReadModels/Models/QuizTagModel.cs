
namespace ArtQuiz.Application.ReadModels.Models;

public class QuizTagModel
{
    public Guid QuizTagId { get; private set; }
    public Guid QuizId { get; private set; }
    
    public string Text { get; private set; }
    public bool IsTrue { get; private set; }
    
    public QuizModel Quiz { get; private set; }
}