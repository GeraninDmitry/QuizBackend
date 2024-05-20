using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect.Events;
using Domain;

namespace ArtQuiz.Domain.QuizRespect;

public class QuizRespect : AggregateRoot<Guid, QuizRespectId>
{
    public QuizId QuizId { get; private set; }
    public string UserId { get; private set; }

    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }

    public DateTime CreatedOn { get; private set; }

    private QuizRespect()
    {
    }

    public QuizRespect(QuizRespectId id, string userId, QuizId quizId, bool isLiked, bool isDisliked) : base(id)
    {
        AssertionConcern.AssertArgumentNotNull(id, "Quiz mark id cannot be null");
        AssertionConcern.AssertArgumentNotNull(userId, "User id cannot be null");
        AssertionConcern.AssertArgumentNotNull(quizId, "Quiz id cannot be null");

        if (isLiked && isDisliked)
            throw new InvalidOperationException("Quiz mark cannot be liked and disliked at the same time");

        if (isLiked != IsLiked)
            ProduceEvent(new QuizLikeCreated(id, userId, quizId, isLiked), Apply);

        if (isDisliked != IsDisliked)
            ProduceEvent(new QuizDislikeCreated(id, userId, quizId, isDisliked), Apply);
    }

    public void Change(bool isLiked, bool isDisliked)
    {
        if (isLiked && isDisliked)
            throw new InvalidOperationException("Quiz mark cannot be liked and disliked at the same time");

        if (isLiked != IsLiked)
            ProduceEvent(new QuizLikeChanged(Id, UserId, QuizId, isLiked), Apply);

        if (isDisliked != IsDisliked)
            ProduceEvent(new QuizDislikeChanged(Id, UserId, QuizId, isDisliked), Apply);
    }

    private void Apply(QuizDislikeChanged @event)
    {
        IsDisliked = @event.IsDisliked;
        
        if(@event.IsDisliked)
            IsLiked = false;
    }

    private void Apply(QuizLikeChanged @event)
    {
        IsLiked = @event.IsLiked;
        
        if(@event.IsLiked)
            IsDisliked = false;
    }

    private void Apply(QuizLikeCreated @event)
    {
        IsLiked = @event.IsLiked;
        QuizId = @event.QuizId;
        UserId = @event.UserId;
        CreatedOn = @event.OccurredOn;
    }

    private void Apply(QuizDislikeCreated @event)
    {
        IsDisliked = @event.IsDisliked;
        QuizId = @event.QuizId;
        UserId = @event.UserId;
        CreatedOn = @event.OccurredOn;
    }
}