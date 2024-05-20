namespace ArtQuiz.Application.Commands.CreateUserApiKeyCommand;

public sealed partial class CreateUserApiKeyCommand {
    private static Results.SuccessResult Success(string value) => new Results.SuccessResult(value);
    private static Results.ConflictResult Conflict(string message) => new Results.ConflictResult(message);
    private static Results.NotFoundResult NotFound(string message) => new Results.NotFoundResult(message);

    public static class Results {
        public sealed class SuccessResult
        {
            public SuccessResult(string value) => Value = value;
            public string Value { get; }
        }

        public sealed class ConflictResult {
            public ConflictResult(string message) => Message = message;
            public string Message { get; }
        }
        
        public sealed class NotFoundResult {
            public NotFoundResult(string message) => Message = message;
            public string Message { get; }
        }
    }
}