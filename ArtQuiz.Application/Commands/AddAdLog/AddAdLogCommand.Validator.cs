using FluentValidation;

namespace ArtQuiz.Application.Commands.AddAdLogCommand;

public sealed partial class AddAdLogCommand
{
    public sealed class Validator : AbstractValidator<AddAdLogCommand>
    {
        public Validator()
        {
            RuleFor(t => t.AdId).NotNull();
        }
    }
}