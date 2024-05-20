using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Infrastructure.Repositories.Quiz.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Quiz;

public sealed class QuizzesRepository :
    AggregateRootRepository<Guid, QuizId, Domain.Quiz.Quiz, QuizzesConfiguration, QuizzesDbContext>, IQuizzesRepository {
    public QuizzesRepository(QuizzesDbContext context) : base(context) { }

    public override Task<Domain.Quiz.Quiz> FindById(QuizId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);
}