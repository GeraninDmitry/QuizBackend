using FluentValidation;

namespace ArtQuiz.Application.Commands.AddUserAvatarCommand;

public sealed partial class AddUserAvatarCommand
{
    public sealed class Validator : AbstractValidator<AddUserAvatarCommand>
    {
        public Validator()
        {
            RuleFor(t => t.UserId).NotNull();
        }
    }
}