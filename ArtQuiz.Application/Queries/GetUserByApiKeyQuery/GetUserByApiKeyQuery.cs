using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetUserByApiKeyQuery
{
    public sealed partial class GetUserByApiKeyQuery : IQuery<OneOf<
        GetUserByApiKeyQuery.Results.SuccessResult,
        GetUserByApiKeyQuery.Results.NotFoundResult>>
    {
        public GetUserByApiKeyQuery(string apiKeyValue) => ApiKeyValue = apiKeyValue;

        private string ApiKeyValue { get; }
    }
}
