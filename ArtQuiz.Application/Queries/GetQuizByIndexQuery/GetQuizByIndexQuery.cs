using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizByIndexQuery
{
    public sealed partial class GetQuizByIndexQuery : IQuery<OneOf<
        GetQuizByIndexQuery.Results.SuccessResult>>
    {
        public GetQuizByIndexQuery(string userId, uint quizIndex, bool isAuthorized, ApplicationTypeEnum applicationType)
        {
            UserId = userId;
            QuizIndex = quizIndex;
            IsAuthorized = isAuthorized;
            ApplicationType = applicationType;
        }

        private string UserId { get; set; }
        private uint QuizIndex { get; set; }
        private bool IsAuthorized { get; set; }
        private ApplicationTypeEnum ApplicationType { get; set; }
    }
}