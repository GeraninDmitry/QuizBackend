using Domain;

namespace ArtQuiz.Domain.UserImage.Events;

public sealed class UserImageCreated : DomainEvent<Guid, UserImageId>
{
    public UserImageCreated(UserImageId aggregateId, string userId, string image)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        UserId = userId;
        Image = image;
    }

    public string UserId { get; }
    public string Image { get; }
}