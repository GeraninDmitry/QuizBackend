using ArtQuiz.Application;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.UserApiKeys;
using ArtQuiz.Infrastructure.Repositories.UserApiKeys.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserApiKeys;

public sealed class UserApiKeysRepository :
    AggregateRootRepository<Guid, UserApiKeyId, Domain.UserApiKeys.UserApiKey, UserApiKeysConfiguration, UserApiKeysDbContext>, IUserApiKeysRepository {
    public UserApiKeysRepository(UserApiKeysDbContext context) : base(context) { }

    public override Task<Domain.UserApiKeys.UserApiKey> FindById(UserApiKeyId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);
}