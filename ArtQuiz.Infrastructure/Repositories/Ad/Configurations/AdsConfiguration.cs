using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.Ad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Ad.Configurations;


public sealed class AdsConfiguration : AggregateRootTypeConfiguration<Guid, AdId, Domain.Ad.Ad> {
    public override void Configure(EntityTypeBuilder<Domain.Ad.Ad> builder) {
        
        builder.ToTable("Ad");
        
        builder.Property(p => p.Application)
            .HasConversion<int>(vo => vo, v => ApplicationType.Parse(v));
        
        builder.Property(p => p.Language)
            .HasConversion<int>(vo => vo, v => LanguageType.Parse(v));
        
        base.Configure(builder);
    }
}