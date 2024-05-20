using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetUserByIdQuery
{
    public sealed partial class GetUserByIdQuery : IQuery<OneOf<
        GetUserByIdQuery.Results.SuccessResult>>
    {
        public GetUserByIdQuery(string userId, bool isAuthorized)
        {
            UserId = userId;
            IsAuthorized = isAuthorized;
        }

        private string UserId { get; set; }
        private bool IsAuthorized { get; set; }
    }
}