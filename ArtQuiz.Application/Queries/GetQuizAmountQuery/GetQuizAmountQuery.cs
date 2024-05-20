using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizAmountQuery
{
    public sealed partial class GetQuizAmountQuery : IQuery<OneOf<
        GetQuizAmountQuery.Results.SuccessResult>>
    {
        public GetQuizAmountQuery(string userId, bool isAuthorized, ApplicationTypeEnum applicationType)
        {
            UserId = userId;
            IsAuthorized = isAuthorized;
            ApplicationType = applicationType;
        }

        private string? UserId { get; set; }
        private bool IsAuthorized { get; set; }
        private ApplicationTypeEnum ApplicationType { get; set; }
    }
}