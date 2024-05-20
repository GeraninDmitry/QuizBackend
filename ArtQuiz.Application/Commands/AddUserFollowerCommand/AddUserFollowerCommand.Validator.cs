using FluentValidation;

namespace ArtQuiz.Application.Commands.AddUserFollowerCommand;

public sealed partial class AddUserFollowerCommand
{
    public sealed class Validator : AbstractValidator<AddUserFollowerCommand>
    {
        public Validator()
        {
            RuleFor(t => t.UserId).NotNull();
            RuleFor(t => t.FollowedUserId).NotNull();
        }
    }
}