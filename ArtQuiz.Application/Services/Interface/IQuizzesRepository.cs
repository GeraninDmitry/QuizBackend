using ArtQuiz.Domain.Quiz;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IQuizzesRepository : IAggregateRootRepository<Guid, QuizId, Quiz>
{
}