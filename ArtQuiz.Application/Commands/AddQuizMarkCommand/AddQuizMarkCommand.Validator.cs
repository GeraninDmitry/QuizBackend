using FluentValidation;

namespace ArtQuiz.Application.Commands.AddQuizMarkCommand;

public sealed partial class AddQuizMarkCommand
{
    public sealed class Validator : AbstractValidator<AddQuizMarkCommand>
    {
        public Validator()
        {
            RuleFor(t => t.UserId).NotNull();
        }
    }
}