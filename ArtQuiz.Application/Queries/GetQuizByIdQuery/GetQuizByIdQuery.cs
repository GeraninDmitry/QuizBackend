using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizByIdQuery
{
    public sealed partial class GetQuizByIdQuery : IQuery<OneOf<
        GetQuizByIdQuery.Results.SuccessResult>>
    {
        public GetQuizByIdQuery(string userId, Guid quizId, bool isAuthorized)
        {
            UserId = userId;
            QuizId = quizId;
            IsAuthorized = isAuthorized;
        }

        private string? UserId { get; set; }
        private Guid QuizId { get; set; }
        private bool IsAuthorized { get; set; }
    }
}