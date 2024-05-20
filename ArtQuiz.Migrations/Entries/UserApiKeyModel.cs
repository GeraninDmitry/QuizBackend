using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class UserApiKeyModel
{
    public Guid UserApiKeyId { get; set; }
    public string Value { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class UserApiKeyModelConfiguration : IEntityTypeConfiguration<UserApiKeyModel>
{
    public void Configure(EntityTypeBuilder<UserApiKeyModel> builder)
    {
        builder.ToTable("UserApiKey");
        builder.HasKey(p => p.UserApiKeyId);
        builder.Property(p => p.Value);
        builder.Property(p => p.CreatedOn);
        builder.Property(p => p.Version);

        builder.HasOne<IdentityUser>()
            .WithOne()
            .HasForeignKey<UserApiKeyModel>(p => p.UserId);
    }
}