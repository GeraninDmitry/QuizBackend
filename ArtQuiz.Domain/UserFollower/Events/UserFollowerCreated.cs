using Domain;

namespace ArtQuiz.Domain.UserFollower.Events;

public sealed class UserFollowerCreated : DomainEvent<Guid, UserFollowerId>
{
    public UserFollowerCreated(UserFollowerId aggregateId, string userId, string followedUserId, bool isFollowing)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        FollowedUserId = followedUserId;
        IsFollowing = isFollowing;
    }

    public string UserId { get; }
    public string FollowedUserId { get; }
    public bool IsFollowing { get; }
}