namespace ArtQuiz.Application.Commands.AddUserFollowerCommand;

public sealed partial class AddUserFollowerCommand
{
    private static Results.SuccessResult Success(Guid followerId) => new Results.SuccessResult(followerId);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid followerId) => FollowerId = followerId;
            public Guid FollowerId { get; }
        }
        
    }
}