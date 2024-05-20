using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using ArtQuiz.Infrastructure.Repositories.QuizMark.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizMark;

public sealed class QuizMarksRepository :
    AggregateRootRepository<Guid, QuizMarkId, Domain.QuizMark.QuizMark, QuizMarksConfiguration, QuizMarksDbContext>, IQuizMarksRepository
{
    public QuizMarksRepository(QuizMarksDbContext context) : base(context)
    {
    }

    public override Task<Domain.QuizMark.QuizMark> FindById(QuizMarkId aggregateRootId, CancellationToken cancellationToken = default)
        => Aggregates
            .Where(t => t.Id == aggregateRootId)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Domain.QuizMark.QuizMark> FindByUserIdAndQuizIdAndType(string userId, QuizId quizId, QuizMarkType type,
        CancellationToken cancellationToken)
        => Aggregates
            .Where(t => t.UserId == userId && t.QuizId == quizId && t.Type == type)
            .FirstOrDefaultAsync(cancellationToken);
}