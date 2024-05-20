using ArtQuiz.Domain.UserImage;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IUserImagesRepository : IAggregateRootRepository<Guid, UserImageId, UserImage>
{
    Task<UserImage> FindByUserId(string userId, CancellationToken cancellationToken);
}