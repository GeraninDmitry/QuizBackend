namespace ArtQuiz.Application.Models;

public class QuizTagDataModel
{
    public Guid QuizTagId { get; private set; }
    public string Text { get; private set; }
    public bool IsTrue { get; private set; }
}