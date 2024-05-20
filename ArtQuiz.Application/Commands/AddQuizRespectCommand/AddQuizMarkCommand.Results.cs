namespace ArtQuiz.Application.Commands.AddQuizRespectCommand;

public sealed partial class AddQuizRespectCommand
{
    private static Results.SuccessResult Success(Guid respectId) => new Results.SuccessResult(respectId);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid respectId) => RespectId = respectId;
            public Guid RespectId { get; }
        }
        
    }
}