using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class UserFollowerModel
{
    public Guid UserFollowerId { get; set; }
    public string UserId { get; set; }
    public string FollowedUserId { get; set; }
    public bool IsFollowing { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class UserFollowerModelConfiguration : IEntityTypeConfiguration<UserFollowerModel>
{
    public void Configure(EntityTypeBuilder<UserFollowerModel> builder)
    {
        builder.ToTable("UserFollower");
        builder.HasKey(p => p.UserFollowerId);
        
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.FollowedUserId).IsRequired();
        builder.Property(p => p.IsFollowing).IsRequired();
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
        
        builder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
        
        builder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(p => p.FollowedUserId);
    }
}