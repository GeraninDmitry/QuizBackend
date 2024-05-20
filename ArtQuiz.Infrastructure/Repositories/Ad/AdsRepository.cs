using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.Ad;
using ArtQuiz.Infrastructure.Repositories.Ad.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Ad;

public sealed class AdsRepository :
    AggregateRootRepository<Guid, AdId, Domain.Ad.Ad, AdsConfiguration, AdsDbContext>, IAdsRepository
{
    public AdsRepository(AdsDbContext context) : base(context)
    {
    }

    public override Task<Domain.Ad.Ad> FindById(AdId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);
}