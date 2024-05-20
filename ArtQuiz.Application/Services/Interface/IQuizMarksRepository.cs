using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IQuizMarksRepository : IAggregateRootRepository<Guid, QuizMarkId, QuizMark>
{
    Task<QuizMark> FindByUserIdAndQuizIdAndType(string requestUserId, QuizId quizId, QuizMarkType type, CancellationToken cancellationToken);
}