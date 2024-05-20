using ArtQuiz.Domain.UserApiKeys;
using ArtQuiz.Infrastructure.Repositories.UserApiKeys.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserApiKeys;

public sealed class UserApiKeysDbContext : AggregateRootDbContext<Guid, UserApiKeyId, Domain.UserApiKeys.UserApiKey, UserApiKeysConfiguration>
{
    public UserApiKeysDbContext(DbContextOptions<UserApiKeysDbContext> options) : base(options)
    {
    }
}