using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetApiKeyByUserQuery
{
    public sealed partial class GetApiKeyByUserQuery : IQuery<OneOf<
        GetApiKeyByUserQuery.Results.SuccessResult,
        GetApiKeyByUserQuery.Results.NotFoundResult>>
    {
        public GetApiKeyByUserQuery(string userId) => UserId = userId;

        private string UserId { get; }
    }
}
