using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetSubscriptionsQuery
{
    public sealed partial class GetSubscriptionsQuery : IQuery<OneOf<
        GetSubscriptionsQuery.Results.SuccessResult>>
    {
        public GetSubscriptionsQuery(string userId)
        {
            UserId = userId;
        }

        private string UserId { get; set; }
    }
}