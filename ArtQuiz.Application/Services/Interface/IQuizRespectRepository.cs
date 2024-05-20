using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IQuizRespectRepository : IAggregateRootRepository<Guid, QuizRespectId, QuizRespect>
{
    Task<Domain.QuizRespect.QuizRespect> FindByUserIdAndQuizId(string userId, QuizId quizId, CancellationToken cancellationToken = default);
}