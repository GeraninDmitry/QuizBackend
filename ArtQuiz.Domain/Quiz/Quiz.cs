using ArtQuiz.Domain.Quiz.Events;
using ArtQuiz.Domain.QuizMark;
using Domain;

namespace ArtQuiz.Domain.Quiz;

public sealed class Quiz : AggregateRoot<Guid, QuizId>
{
    public string UserId { get; private set; }

    public QuizType Type { get; private set; }
    public QuizStatus Status { get; private set; }
    public QuizTheme Theme { get; private set; }
    public ApplicationType Application { get; private set; }
    public LanguageType Language { get; private set; }
    
    public string Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }
    
    public IEnumerable<QuizTag> QuizTags { get; private set; }

    public DateTime CreatedOn { get; private set; }
    
    private Quiz () { }

    public Quiz(QuizId id, string userId, QuizType type, QuizTheme theme, ApplicationType applicationType, LanguageType languageType,
        string title, string text, IEnumerable<QuizTag> tags) : base(id)
    {
        
        AssertionConcern.AssertArgumentNotNull(id, "Quiz id cannot be null");
        AssertionConcern.AssertArgumentNotNull(userId, "User id cannot be null");
        AssertionConcern.AssertArgumentNotNull(type, "Quiz type cannot be null");
        AssertionConcern.AssertArgumentNotNull(title, "Quiz title cannot be null");
        AssertionConcern.AssertArgumentNotNull(text, "Quiz text cannot be null");
        AssertionConcern.AssertArgumentNotNull(tags, "Quiz tags cannot be null");
        AssertionConcern.AssertArgumentNotEquals(type, QuizType.Undefined, "Quiz type cannot be undefined");
        AssertionConcern.AssertArgumentNotEquals(type, QuizType.Ad, "Quiz type cannot be ad");
        AssertionConcern.AssertArgumentNotEquals(theme, QuizTheme.Undefined, "Quiz theme cannot be undefined");

        if (tags.Count() != 4)
            throw new InvalidOperationException("Quiz tags must be 4");

        if (tags.Count(i => i.IsTrue == false) != 3 || tags.Count(i => i.IsTrue == true) != 1)
            throw new InvalidOperationException("Quiz tags must be 3 false and 1 true");

        foreach (var tag in tags)
            AssertionConcern.AssertArgumentLength(tag.Text, 1, 50, "Quiz tag must be between 1 and 50 characters");

        AssertionConcern.AssertArgumentLength(title, 1, 100, "Quiz title must be between 1 and 100 characters");
        AssertionConcern.AssertArgumentLength(text, 1, 1000, "Quiz text must be between 1 and 1000 characters");
        
        ProduceEvent(new TextQuizCreated(id, userId, type, theme, applicationType, languageType, title, text, tags), Apply);
    }

    public Quiz(QuizId id, string userId, string title, string image, QuizType type, QuizTheme theme,
        ApplicationType applicationType, LanguageType languageType, IEnumerable<QuizTag> tags) : base(id)
    {
        AssertionConcern.AssertArgumentNotNull(id, "Quiz id cannot be null");
        AssertionConcern.AssertArgumentNotNull(userId, "User id cannot be null");
        AssertionConcern.AssertArgumentNotNull(type, "Quiz type cannot be null");
        AssertionConcern.AssertArgumentNotNull(title, "Quiz title cannot be null");
        AssertionConcern.AssertArgumentNotNull(image, "Quiz image cannot be null");
        AssertionConcern.AssertArgumentNotNull(tags, "Quiz tags cannot be null");
        AssertionConcern.AssertArgumentNotEquals(type, QuizType.Undefined, "Quiz type cannot be undefined");
        AssertionConcern.AssertArgumentNotEquals(type, QuizType.Ad, "Quiz type cannot be ad");
        AssertionConcern.AssertArgumentNotEquals(theme, QuizTheme.Undefined, "Quiz theme cannot be undefined");

        if (tags.Count() != 4)
            throw new InvalidOperationException("Quiz tags must be 4");

        if (tags.Count(i => i.IsTrue == false) != 3 || tags.Count(i => i.IsTrue == true) != 1)
            throw new InvalidOperationException("Quiz tags must be 3 false and 1 true");
        
        foreach (var tag in tags)
            AssertionConcern.AssertArgumentLength(tag.Text, 1, 50, "Quiz tag must be between 1 and 50 characters");
        
        AssertionConcern.AssertArgumentLength(title, 1, 100, "Quiz title must be between 1 and 100 characters");

        ProduceEvent(new ImageQuizCreated(id, userId, type, theme, applicationType, languageType, title, image, tags), Apply);
    }

    private void Apply(ImageQuizCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        Type = @event.Type;
        Theme = @event.Theme;
        Status = QuizStatus.InProgress;
        Title = @event.Title;
        Image = @event.Image;
        QuizTags = @event.QuizTags;
        Application = @event.ApplicationType;
        Language = @event.LanguageType;
    }

    private void Apply(TextQuizCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        Type = @event.Type;
        Theme = @event.Theme;
        Status = QuizStatus.InProgress;
        Title = @event.Title;
        Text = @event.Text;
        QuizTags = @event.QuizTags;
        Application = @event.ApplicationType;
        Language = @event.LanguageType;
    }
}