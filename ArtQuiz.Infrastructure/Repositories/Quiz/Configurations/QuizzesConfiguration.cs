using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Quiz.Configurations;


public sealed class QuizzesConfiguration : AggregateRootTypeConfiguration<Guid, QuizId, Domain.Quiz.Quiz> {
    public override void Configure(EntityTypeBuilder<Domain.Quiz.Quiz> builder) {
        
        builder.ToTable("Quiz");
        
        builder.Property(p => p.Type)
            .HasConversion<int>(vo => vo, v => QuizType.Parse(v));
        
        builder.Property(p => p.Status)
            .HasConversion<int>(vo => vo, v => QuizStatus.Parse(v));
        
        builder.Property(p => p.Theme)
            .HasConversion<int>(vo => vo, v => QuizTheme.Parse(v));

        builder.Property(p => p.Application)
            .HasConversion<int>(vo => vo, v => ApplicationType.Parse(v));
        
        builder.Property(p => p.Language)
            .HasConversion<int>(vo => vo, v => LanguageType.Parse(v));
        
        builder.HasMany(p => p.QuizTags)
            .WithOne()
            .HasForeignKey("QuizId")
            .HasPrincipalKey(p => p.Id);
        
        base.Configure(builder);
    }
}