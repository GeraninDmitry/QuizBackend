namespace ArtQuiz.Application.Commands.AddQuizMarkCommand;

public sealed partial class AddQuizMarkCommand
{
    private static Results.SuccessResult Success(Guid markId) => new Results.SuccessResult(markId);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid markId) => MarkId = markId;
            public Guid MarkId { get; }
        }
        
    }
}