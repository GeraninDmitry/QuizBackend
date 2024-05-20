using ArtQuiz.Domain.Ad;
using ArtQuiz.Infrastructure.Repositories.Ad.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Ad;

public sealed class AdsDbContext : AggregateRootDbContext<Guid, AdId, Domain.Ad.Ad, AdsConfiguration>
{
    public AdsDbContext(DbContextOptions<AdsDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new AdsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}