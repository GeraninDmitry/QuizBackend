namespace ArtQuiz.Application.Commands.SendVerificationCodeCommand;

public sealed partial class SendVerificationCodeCommand {
    private static Results.SuccessResult Success() => new Results.SuccessResult();
    private static Results.NotFoundResult NotFound(string message) => new Results.NotFoundResult(message);

    public static class Results {
        public sealed class SuccessResult { }

        public sealed class NotFoundResult {
            public NotFoundResult(string message) => Message = message;
            public string Message { get; }
        }
    }
}