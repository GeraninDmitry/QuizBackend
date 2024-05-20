using ArtQuiz.Domain.Quiz;
using Domain;

namespace ArtQuiz.Domain.QuizMark.Events;

public sealed class QuizMarkCreated : DomainEvent<Guid, QuizMarkId> {

    public QuizMarkCreated(QuizMarkId aggregateId, string userId, QuizId quizId, QuizMarkType type, bool isActive)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        QuizId = quizId;
        Type = type;
        IsActive = isActive;
    }

   
    public QuizId QuizId { get; set; }
    public string UserId { get; set; }
    
    public QuizMarkType Type { get; set; }
    public bool IsActive { get; set; }
}