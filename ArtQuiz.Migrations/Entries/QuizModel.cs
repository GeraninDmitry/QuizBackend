using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class QuizModel
{
    public Guid QuizId { get; set; }
    public string UserId { get; set; }
    
    public int Type { get; set; }
    public int Status { get; set; }
    public int Theme { get; set; }
    public int Application { get; set; }
    public int Language { get; set; }
    
    public string Title { get; set; }
    public string Image { get; set; }
    public string Text { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
    
}

public sealed class QuizModelConfiguration : IEntityTypeConfiguration<QuizModel>
{
    public void Configure(EntityTypeBuilder<QuizModel> builder)
    {
        
        builder.ToTable("Quiz");
        builder.HasKey(p => p.QuizId);
        
        builder.Property(p => p.Type)
            .IsRequired();
        
        builder.Property(p => p.Status)
            .IsRequired();
        
        builder.Property(p => p.Theme)
            .IsRequired();
        
        builder.Property(p => p.Application)
            .IsRequired();
        
        builder.Property(p => p.Language)
            .IsRequired();

        builder
            .Property(p => p.Title)
            .IsRequired(false);
        
        builder
            .Property(p => p.Image)
            .IsRequired(false);
        
        builder
            .Property(p => p.Text)
            .IsRequired(false);
        
        builder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
        
        builder.Property(p => p.CreatedOn)
            .IsRequired();
        
        builder.Property(p => p.Version)
            .IsRequired();
    }
}