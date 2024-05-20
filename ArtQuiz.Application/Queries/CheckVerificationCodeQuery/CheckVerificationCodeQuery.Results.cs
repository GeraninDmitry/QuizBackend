using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.CheckVerificationCodeQuery
{
    public sealed partial class CheckVerificationCodeQuery
    {
        private static Results.SuccessResult Success() => new();
        private static Results.NotFoundResult NotFound(string message) => new(message);
        private static Results.ConflictResult Conflict(string message) => new(message);

        public static class Results
        {
            public sealed class SuccessResult {}
            public sealed class NotFoundResult { public NotFoundResult(string message) => Message = message; public string Message { get; } }
            public sealed class ConflictResult { public ConflictResult(string message) => Message = message; public string Message { get; } }
        }
    }
}
