using Domain;

namespace ArtQuiz.Domain.UserImage;

public sealed class UserImageId : AggregateRootId<Guid, UserImageId> {
    public UserImageId(Guid value) : base(value) { }

    public static UserImageId Parse(string value) => new UserImageId(Guid.Parse(value));
    public static implicit operator string(UserImageId state) => state.Value.ToString();
}