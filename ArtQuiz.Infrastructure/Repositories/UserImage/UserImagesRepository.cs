using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.UserImage;
using ArtQuiz.Infrastructure.Repositories.UserImage.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserImage;

public sealed class UserImagesRepository :
    AggregateRootRepository<Guid, UserImageId, Domain.UserImage.UserImage, UserImagesConfiguration, UserImagesDbContext>, IUserImagesRepository
{
    public UserImagesRepository(UserImagesDbContext context) : base(context)
    {
    }

    public override Task<Domain.UserImage.UserImage> FindById(UserImageId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Domain.UserImage.UserImage> FindByUserId(string userId, CancellationToken cancellationToken)
        => Aggregates
            .Where(t => t.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);
}