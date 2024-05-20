using ArtQuiz.Domain.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Infrastructure.Repositories.Quiz.Configurations;

public class QuizTagsConfiguration : IEntityTypeConfiguration<QuizTag> 
{
    public void Configure(EntityTypeBuilder<QuizTag> builder)
    {
        builder.ToTable("QuizTag");
        
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasColumnName("QuizTagId")
            .HasConversion(vo => vo.Value, v => QuizTagId.With(v));
        
        builder.Property<QuizId>("QuizId")
            .HasConversion(vo => vo.Value, v => QuizId.With(v));
        
    }
    
}