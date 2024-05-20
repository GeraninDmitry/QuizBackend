using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class QuizMarkModel
{
    public Guid QuizMarkId { get; set; }
    public Guid QuizId { get; set; }
    public string UserId { get; set; }
    
    public int Type { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class QuizMarkModelConfiguration : IEntityTypeConfiguration<QuizMarkModel>
{
    public void Configure(EntityTypeBuilder<QuizMarkModel> builder)
    {
        builder.ToTable("QuizMark");
        builder.HasKey(p => p.QuizMarkId);
        
        builder.Property(p => p.Type)
            .IsRequired();
        
        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
        
        builder.HasOne<QuizModel>()
            .WithMany()
            .HasForeignKey(p => p.QuizId);
        
        builder.Property(p => p.CreatedOn)
            .IsRequired();
        
        builder.Property(p => p.Version)
            .IsRequired();
    }
}