using ArtQuiz.Domain.UserFollower.Events;
using Domain;

namespace ArtQuiz.Domain.UserFollower;

public sealed class UserFollower : AggregateRoot<Guid, UserFollowerId>
{
    public string UserId { get; private set; }
    public string FollowedUserId { get; private set; }
    public bool IsFollowing { get; private set; }
    public DateTime CreatedOn { get; private set; }


    private UserFollower()
    {
    }

    public UserFollower(UserFollowerId id, string userId, string followedUserId, bool isFollowing) : base(id)
    {
        AssertionConcern.AssertArgumentNotNull(userId, nameof(userId));
        AssertionConcern.AssertArgumentNotNull(followedUserId, nameof(followedUserId));

        ProduceEvent(new UserFollowerCreated(id, userId, followedUserId, isFollowing), Apply);
    }

    public void Change(bool isFollowing)
    {
        if (isFollowing != IsFollowing)
            ProduceEvent(new UserFollowerChanged(Id, UserId, FollowedUserId, isFollowing), Apply);
    }

    private void Apply(UserFollowerChanged @event)
    {
        IsFollowing = @event.IsFollowing;
    }

    private void Apply(UserFollowerCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        FollowedUserId = @event.FollowedUserId;
        IsFollowing = @event.IsFollowing;
    }
}