namespace ArtQuiz.Application.Commands.AddQuizCommand;

public sealed partial class AddQuizCommand
{
    private static Results.SuccessResult Success(Guid quizId) => new Results.SuccessResult(quizId);
    private static Results.ConflictResult Conflict(string message) => new Results.ConflictResult(message);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid quizId) => QuizId = quizId;
            public Guid QuizId { get; }
        }

        public sealed class ConflictResult
        {
            public ConflictResult(string message) => Message = message;
            public string Message { get; }
        }
    }
}