using ArtQuiz.Domain.Quiz;
using Domain;

namespace ArtQuiz.Domain.QuizRespect.Events;

public sealed class QuizDislikeChanged : DomainEvent<Guid, QuizRespectId>
{
    public QuizDislikeChanged(QuizRespectId aggregateId, string userId, QuizId quizId, bool isDisliked)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        QuizId = quizId;
        IsDisliked = isDisliked;
    }

    public QuizId QuizId { get; }
    public bool IsDisliked { get; }
    public string UserId { get; }
}