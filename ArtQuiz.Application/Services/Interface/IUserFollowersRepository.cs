using ArtQuiz.Domain.UserFollower;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IUserFollowersRepository : IAggregateRootRepository<Guid, UserFollowerId, UserFollower>
{
    Task<UserFollower> FindByUserIdAndFollowedUserId(string userId, string followedUserId, CancellationToken cancellationToken);
}