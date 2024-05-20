using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetApiKeyByUserQuery
{
    public sealed partial class GetApiKeyByUserQuery
    {
        private static Results.SuccessResult Success(string apiKey) => new(apiKey);
        private static Results.NotFoundResult NotFound(string message) => new(message);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(string apiKey) => Value = apiKey; public string Value { get; } }
            public sealed class NotFoundResult { public NotFoundResult(string message) => Message = message; public string Message { get; } }
        }
    }
}
