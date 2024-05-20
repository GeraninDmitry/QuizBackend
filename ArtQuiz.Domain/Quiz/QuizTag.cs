using Domain;

namespace ArtQuiz.Domain.Quiz;

public class QuizTag : Entity<Guid, QuizTagId>
{
    public QuizId QuizId { get; private set; }

    public string Text { get; private set; }
    public bool IsTrue { get; private set; }
    
    
    private QuizTag () { }
    
    public QuizTag(QuizTagId id, QuizId quizId, string text, bool isTrue) : base(id) 
    {
        if(string.IsNullOrEmpty(text))
            throw new InvalidOperationException("Quiz tag text cannot be null or empty");
        
        if(text.Length > 50)
            throw new InvalidOperationException("Quiz tag text cannot be more than 50 characters");
        
        QuizId = quizId;
        Text = text;
        IsTrue = isTrue;
    }
}