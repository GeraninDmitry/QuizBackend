using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetUserByApiKeyQuery
{
    public sealed partial class GetUserByApiKeyQuery
    {
        private static Results.SuccessResult Success(UserApiKeyAppModel value) => new(value);
        private static Results.NotFoundResult NotFound(string message) => new(message);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(UserApiKeyAppModel value) => Value = value; public UserApiKeyAppModel Value { get; } }
            public sealed class NotFoundResult { public NotFoundResult(string message) => Message = message; public string Message { get; } }
        }

        public sealed class UserApiKeyAppModel
        {
            public IdentityUser User { get; set; }
        }
    }
}
