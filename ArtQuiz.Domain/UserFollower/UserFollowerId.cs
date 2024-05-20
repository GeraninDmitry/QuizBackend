using Domain;

namespace ArtQuiz.Domain.UserFollower;

public sealed class UserFollowerId : AggregateRootId<Guid, UserFollowerId> {
    public UserFollowerId(Guid value) : base(value) { }

    public static UserFollowerId Parse(string value) => new UserFollowerId(Guid.Parse(value));
    public static implicit operator string(UserFollowerId state) => state.Value.ToString();
}