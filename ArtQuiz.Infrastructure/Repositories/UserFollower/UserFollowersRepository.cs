using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.UserFollower;
using ArtQuiz.Infrastructure.Repositories.UserFollower.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserFollower;

public sealed class UserFollowersRepository :
    AggregateRootRepository<Guid, UserFollowerId, Domain.UserFollower.UserFollower, UserFollowersConfiguration, UserFollowersDbContext>, IUserFollowersRepository
{
    public UserFollowersRepository(UserFollowersDbContext context) : base(context)
    {
    }

    public override Task<Domain.UserFollower.UserFollower> FindById(UserFollowerId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Domain.UserFollower.UserFollower> FindByUserIdAndFollowedUserId(string userId, string followedUserId, CancellationToken cancellationToken)
        => Aggregates
            .Where(t => t.UserId == userId && t.FollowedUserId == followedUserId)
            .FirstOrDefaultAsync(cancellationToken);

}