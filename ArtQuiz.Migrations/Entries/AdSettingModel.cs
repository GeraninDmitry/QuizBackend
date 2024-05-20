using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class AdSettingModel
{
    public Guid AdSettingId { get; set; }
    
    public int Probability { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class AdSettingModelConfiguration : IEntityTypeConfiguration<AdSettingModel>
{
    public void Configure(EntityTypeBuilder<AdSettingModel> builder)
    {
        builder.ToTable("AdSetting");
        builder.HasKey(p => p.AdSettingId);
        
        builder.Property(p => p.Probability).IsRequired();
        
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
    }
}