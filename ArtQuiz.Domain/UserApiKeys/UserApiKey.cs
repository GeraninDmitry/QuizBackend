using ArtQuiz.Domain.UserApiKeys.Events;
using Domain;

namespace ArtQuiz.Domain.UserApiKeys;


public sealed class UserApiKey : AggregateRoot<Guid, UserApiKeyId>
{
    public string Value { get; private set; }
    public string UserId { get; private set; }
    public DateTime CreatedOn { get; private set; }
    
    private UserApiKey()
    {
    }

    public UserApiKey(UserApiKeyId id, string value, string userId) : base(id)
    {
        ProduceEvent(new UserApiKeyCreated(id, value, userId), Apply);
    }
    
    private void Apply(UserApiKeyCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        Value = @event.Value;
        UserId = @event.UserId;
    }
}