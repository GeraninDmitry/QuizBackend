using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using ArtQuiz.Infrastructure.Repositories.QuizRespect;
using ArtQuiz.Infrastructure.Repositories.QuizRespect.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizRespect;

public sealed class QuizRespectRepository :
    AggregateRootRepository<Guid, QuizRespectId, Domain.QuizRespect.QuizRespect, QuizRespectConfiguration, QuizRespectDbContext>, IQuizRespectRepository {
    public QuizRespectRepository(QuizRespectDbContext context) : base(context) { }

    public override Task<Domain.QuizRespect.QuizRespect> FindById(QuizRespectId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Domain.QuizRespect.QuizRespect> FindByUserIdAndQuizId(string userId, QuizId quizId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.UserId == userId && t.QuizId == quizId)
            .FirstOrDefaultAsync(cancellationToken);
}