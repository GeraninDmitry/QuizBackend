using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class QuizTagModel
{
    public Guid QuizTagId { get; set; }
    public Guid QuizId { get; set; }
    
    public string Text { get; set; }
    public bool IsTrue { get; set; }
}

public sealed class QuizTagModelConfiguration : IEntityTypeConfiguration<QuizTagModel>
{
    public void Configure(EntityTypeBuilder<QuizTagModel> builder)
    {
        builder.ToTable("QuizTag");
        builder.HasKey(p => p.QuizTagId);
        
        builder.Property(p => p.Text)
            .IsRequired();
        
        builder.Property(p => p.IsTrue)
            .IsRequired();
        
        builder.HasOne<QuizModel>()
            .WithMany()
            .HasForeignKey(p => p.QuizId);
    }
}