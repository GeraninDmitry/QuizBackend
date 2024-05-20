using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.AdLog;
using ArtQuiz.Infrastructure.Repositories.AdLog.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.AdLog;

public sealed class AdLogsRepository :
    AggregateRootRepository<Guid, AdLogId, Domain.AdLog.AdLog, AdLogsConfiguration, AdLogsDbContext>, IAdLogsRepository
{
    public AdLogsRepository(AdLogsDbContext context) : base(context)
    {
    }

    public override Task<Domain.AdLog.AdLog> FindById(AdLogId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);
}