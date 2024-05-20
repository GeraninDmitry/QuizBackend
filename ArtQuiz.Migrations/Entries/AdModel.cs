using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class AdModel
{
    public Guid AdId { get; set; }
    
    public int Application { get; set; }
    public int Language { get; set; }

    public string? Title { get; set; }
    public string? Image { get; set; }
    public string? Text { get; set; }
    
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public bool IsRepeating { get; set; }
    public bool? IsForAuthorizedUser { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class AdModelConfiguration : IEntityTypeConfiguration<AdModel>
{
    public void Configure(EntityTypeBuilder<AdModel> builder)
    {
        builder.ToTable("Ad");
        builder.HasKey(p => p.AdId);

        builder.Property(p => p.Application).IsRequired();
        builder.Property(p => p.Language).IsRequired();
        
        builder.Property(p => p.Title).IsRequired(false);
        builder.Property(p => p.Image).IsRequired(false);
        builder.Property(p => p.Text).IsRequired(false);
        
        builder.Property(p => p.StartDate).IsRequired(false);
        builder.Property(p => p.EndDate).IsRequired(false);
        
        builder.Property(p => p.IsRepeating).IsRequired();
        builder.Property(p => p.IsForAuthorizedUser).IsRequired(false);
        builder.Property(p => p.IsActive).IsRequired();
        
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
    }
}