namespace ArtQuiz.Host.Bindings.Quiz;

public class QuizTagResponse
{
    public Guid QuizTagId { get; private set; }
    public string Text { get; private set; }
    public bool IsTrue { get; private set; }
}