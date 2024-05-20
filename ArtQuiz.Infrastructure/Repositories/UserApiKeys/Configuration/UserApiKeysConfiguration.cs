using ArtQuiz.Domain.UserApiKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserApiKeys.Configuration;

public sealed class UserApiKeysConfiguration : AggregateRootTypeConfiguration<Guid, UserApiKeyId, Domain.UserApiKeys.UserApiKey>
{
    public override void Configure(EntityTypeBuilder<Domain.UserApiKeys.UserApiKey> builder)
    {
        builder.ToTable("UserApiKey");

        base.Configure(builder);
    }
}