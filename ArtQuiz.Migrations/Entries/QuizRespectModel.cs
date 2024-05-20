using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class QuizRespectModel
{
    public Guid QuizRespectId { get; set; }
    public Guid QuizId { get; set; }
    public string UserId { get; set; }
    
    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class QuizRespectModelConfiguration : IEntityTypeConfiguration<QuizRespectModel>
{
    public void Configure(EntityTypeBuilder<QuizRespectModel> builder)
    {
        builder.ToTable("QuizRespect");
        builder.HasKey(p => p.QuizRespectId);
        
        builder.Property(p => p.IsLiked)
            .IsRequired();
        
        builder.Property(p => p.IsDisliked)
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