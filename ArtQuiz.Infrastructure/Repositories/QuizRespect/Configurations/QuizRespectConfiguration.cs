using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizRespect.Configurations;


public sealed class QuizRespectConfiguration : AggregateRootTypeConfiguration<Guid, QuizRespectId, Domain.QuizRespect.QuizRespect> {
    public override void Configure(EntityTypeBuilder<Domain.QuizRespect.QuizRespect> builder) {
        
        builder.ToTable("QuizRespect");
        
        builder.Property<QuizId>("QuizId")
            .HasConversion(vo => vo.Value, v => QuizId.With(v));
        
        base.Configure(builder);
    }
}