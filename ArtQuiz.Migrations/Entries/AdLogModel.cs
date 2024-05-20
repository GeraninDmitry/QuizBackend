using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class AdLogModel
{
    public Guid AdLogId { get; set; }
    public Guid AdId { get; set; }
    
    public string? UserId { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class AdLogModelConfiguration : IEntityTypeConfiguration<AdLogModel>
{
    public void Configure(EntityTypeBuilder<AdLogModel> builder)
    {
        builder.ToTable("AdLog");
        builder.HasKey(p => p.AdLogId);
        
        builder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired(false);
        
        builder.HasOne<AdModel>()
            .WithMany()
            .HasForeignKey(p => p.AdId)
            .IsRequired(true);
        
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
    }
}