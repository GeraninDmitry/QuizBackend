using Domain;

namespace ArtQuiz.Domain.QuizMark.Events;



public sealed class ActiveStatusChanged : DomainEvent<Guid, QuizMarkId> {

    public ActiveStatusChanged(QuizMarkId aggregateId, string userId, Guid quizId, QuizMarkType type, bool isActive)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        QuizId = quizId;
        Type = type;
        IsActive = isActive;
    }

   
    public Guid QuizId { get; set; }
    public string UserId { get; set; }
    
    public QuizMarkType Type { get; set; }
    public bool IsActive { get; set; }
}