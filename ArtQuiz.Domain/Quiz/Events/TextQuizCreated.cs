using Domain;

namespace ArtQuiz.Domain.Quiz.Events;

public sealed class TextQuizCreated : DomainEvent<Guid, QuizId>
{
    public TextQuizCreated(QuizId aggregateId, string userId, QuizType type, QuizTheme theme, ApplicationType applicationType,
        LanguageType languageType, string title, string text, IEnumerable<QuizTag> quizTags)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        Type = type;
        Theme = theme;
        ApplicationType = applicationType;
        LanguageType = languageType;
        Title = title;
        Text = text;
        QuizTags = quizTags;
    }

    public string UserId { get; private set; }

    public QuizType Type { get; private set; }
    public QuizTheme Theme { get; private set;}
    public ApplicationType ApplicationType { get; private set;}
    public LanguageType LanguageType { get; private set;}

    public string Title { get; private set; }
    public string Text { get; private set; }

    public IEnumerable<QuizTag> QuizTags { get; set; }
}