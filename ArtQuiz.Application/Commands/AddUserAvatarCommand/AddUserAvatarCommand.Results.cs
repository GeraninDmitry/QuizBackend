namespace ArtQuiz.Application.Commands.AddUserAvatarCommand;

public sealed partial class AddUserAvatarCommand
{
    private static Results.SuccessResult Success(Guid avatarId) => new Results.SuccessResult(avatarId);

    public static class Results
    {
        public sealed class SuccessResult
        {
            public SuccessResult(Guid avatarId) => AvatarId = avatarId;
            public Guid AvatarId { get; }
        }
        
    }
}