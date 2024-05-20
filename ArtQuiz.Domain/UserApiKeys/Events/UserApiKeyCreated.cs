using Domain;

namespace ArtQuiz.Domain.UserApiKeys.Events;


public sealed class UserApiKeyCreated : DomainEvent<Guid, UserApiKeyId> {

    public UserApiKeyCreated(UserApiKeyId aggregateId, string value, string userId)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        Value = value;
        UserId = userId;
    }

    public string Value { get; set; }
    public string UserId { get; set; }
}