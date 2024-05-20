using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark.Events;
using Domain;

namespace ArtQuiz.Domain.QuizMark;

public class QuizMark : AggregateRoot<Guid, QuizMarkId>
{
    public QuizId QuizId { get; private set; }
    public string UserId { get; private set; }

    public QuizMarkType Type { get; private set; }
    public bool IsActive { get; private set; }

    public DateTime CreatedOn { get; private set; }
    
    private QuizMark()
    {
    }

    public QuizMark(QuizMarkId id, string userId, QuizId quizId, QuizMarkType type, bool isActive) : base(id)
    {
        AssertionConcern.AssertArgumentNotNull(id, "Quiz mark id cannot be null");
        AssertionConcern.AssertArgumentNotNull(userId, "User id cannot be null");
        AssertionConcern.AssertArgumentNotEquals(type, QuizMarkType.Undefined, "Quiz mark type cannot be undefined");

        ProduceEvent(new QuizMarkCreated(id, userId, quizId, type, isActive), Apply);
    }

    private void Apply(QuizMarkCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        Type = @event.Type;
        IsActive = @event.IsActive;
        QuizId = @event.QuizId;
    }

    public void ChangeActiveStatus(bool isActive)
    {
        if (IsActive != isActive)
            ProduceEvent(new ActiveStatusChanged(Id, UserId, QuizId, Type, isActive), Apply);
    }

    private void Apply(ActiveStatusChanged @event)
    {
         IsActive = @event.IsActive;
    }
    
}