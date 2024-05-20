using ArtQuiz.Domain.UserImage.Events;
using Domain;

namespace ArtQuiz.Domain.UserImage;

public sealed class UserImage : AggregateRoot<Guid, UserImageId>
{
    public string UserId { get; set; }
    public string Image { get; set; }
    public DateTime CreatedOn { get; private set; }


    private UserImage()
    {
    }

    public UserImage(UserImageId id, string userId, string image) : base(id)
    {
        AssertionConcern.AssertArgumentNotNull(userId, nameof(userId));
        AssertionConcern.AssertArgumentNotNull(image, nameof(image));

        ProduceEvent(new UserImageCreated(id, userId, image), Apply);
    }
    
    private void Apply(UserImageCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        Image = @event.Image;
    }

    public void ChangeImage(string imageName)
    {
        AssertionConcern.AssertArgumentNotNull(imageName, nameof(imageName));

        ProduceEvent(new UserImageChanged(Id, UserId, imageName), Apply);
    }

    private void Apply(UserImageChanged @event)
    {
        CreatedOn = @event.OccurredOn;
        Image = @event.Image;
    }
}