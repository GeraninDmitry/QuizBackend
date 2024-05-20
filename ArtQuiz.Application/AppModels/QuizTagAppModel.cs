namespace ArtQuiz.Application.AppModels;

public class QuizTagAppModel
{
    public Guid QuizTagId { get; private set; }
    public string Text { get; private set; }
    public bool IsTrue { get; private set; }
}