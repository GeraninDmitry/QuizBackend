using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class UserImageModel
{
    public Guid UserImageId { get; set; }
    public string UserId { get; set; }
    public string Image { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class UserImageModelConfiguration : IEntityTypeConfiguration<UserImageModel>
{
    public void Configure(EntityTypeBuilder<UserImageModel> builder)
    {
        builder.ToTable("UserImage");
        builder.HasKey(p => p.UserImageId);
        
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Image).IsRequired(false);
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
        
        builder.HasOne<IdentityUser>()
            .WithOne()
            .HasForeignKey<UserImageModel>(p => p.UserId);
        
    }
}