namespace ArtQuiz.Application.Commands.AddAdLogCommand;

public sealed partial class AddAdLogCommand
{
    private static Results.SuccessResult Success(Guid value) => new Results.SuccessResult(value);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid value) => Value = value;
            public Guid Value { get; }
        }
        
    }
}