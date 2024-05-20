using Domain;

namespace ArtQuiz.Domain.UserApiKeys;

public sealed class UserApiKeyId : AggregateRootId<Guid, UserApiKeyId> {
    public UserApiKeyId(Guid value) : base(value) { }

    public static UserApiKeyId Parse(string value) => new UserApiKeyId(Guid.Parse(value));
    public static implicit operator string(UserApiKeyId state) => state.Value.ToString();
}