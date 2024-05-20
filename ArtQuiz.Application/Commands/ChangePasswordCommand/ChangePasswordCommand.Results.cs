namespace ArtQuiz.Application.Commands.ChangePasswordCommand;

public sealed partial class ChangePasswordCommand {
    private static Results.SuccessResult Success() => new Results.SuccessResult();
    private static Results.ConflictResult Conflict(string message) => new Results.ConflictResult(message);
    private static Results.NotFoundResult NotFound(string message) => new Results.NotFoundResult(message);

    public static class Results {
        public sealed class SuccessResult { }

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