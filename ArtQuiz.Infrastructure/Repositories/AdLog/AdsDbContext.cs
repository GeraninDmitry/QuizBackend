using ArtQuiz.Domain.AdLog;
using ArtQuiz.Infrastructure.Repositories.AdLog.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.AdLog;

public sealed class AdLogsDbContext : AggregateRootDbContext<Guid, AdLogId, Domain.AdLog.AdLog, AdLogsConfiguration>
{
    public AdLogsDbContext(DbContextOptions<AdLogsDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new AdLogsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}