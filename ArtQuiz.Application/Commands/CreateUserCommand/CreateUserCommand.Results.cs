namespace ArtQuiz.Application.Commands.CreateUserCommand;

public sealed partial class CreateUserCommand {
    private static Results.SuccessResult Success() => new Results.SuccessResult();
    private static Results.ConflictResult Conflict(string message) => new Results.ConflictResult(message);

    public static class Results {
        public sealed class SuccessResult { }

        public sealed class ConflictResult {
            public ConflictResult(string message) => Message = message;
            public string Message { get; }
        }
    }
}