using ArtQuiz.Domain.Quiz;
using Domain;

namespace ArtQuiz.Domain.QuizRespect.Events;


public sealed class QuizLikeChanged : DomainEvent<Guid, QuizRespectId>
{
    public QuizLikeChanged(QuizRespectId aggregateId, string userId, QuizId quizId, bool isLiked)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        QuizId = quizId;
        IsLiked = isLiked;
    }

    public QuizId QuizId { get; }
    public bool IsLiked { get; }
    public string UserId { get; }
}