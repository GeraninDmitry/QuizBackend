using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizMark.Configurations;


public sealed class QuizMarksConfiguration : AggregateRootTypeConfiguration<Guid, QuizMarkId, Domain.QuizMark.QuizMark> {
    public override void Configure(EntityTypeBuilder<Domain.QuizMark.QuizMark> builder) {
        
        builder.ToTable("QuizMark");
        
        builder.Property(p => p.Type)
            .HasConversion<int>(vo => vo, v => QuizMarkType.Parse(v));
        
        builder.Property<QuizId>("QuizId")
            .HasConversion(vo => vo.Value, v => QuizId.With(v));
        
        base.Configure(builder);
    }
}