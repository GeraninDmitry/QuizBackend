using ArtQuiz.Domain;
using ArtQuiz.Domain.Ad;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.AdLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.AdLog.Configurations;


public sealed class AdLogsConfiguration : AggregateRootTypeConfiguration<Guid, AdLogId, Domain.AdLog.AdLog> {
    public override void Configure(EntityTypeBuilder<Domain.AdLog.AdLog> builder) {
        
        builder.ToTable("AdLog");
        
        builder.Property<AdId>("AdId")
            .HasConversion(vo => vo.Value, v => AdId.With(v));
        
        base.Configure(builder);
    }
}