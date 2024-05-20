using FluentValidation;

namespace ArtQuiz.Application.Commands.AddQuizRespectCommand;

public sealed partial class AddQuizRespectCommand
{
    public sealed class Validator : AbstractValidator<AddQuizRespectCommand>
    {
        public Validator()
        {
            RuleFor(t => t.UserId).NotNull();
        }
    }
}