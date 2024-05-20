using FluentValidation;

namespace ArtQuiz.Application.Commands.AddQuizCommand;

public sealed partial class AddQuizCommand
{
    public sealed class Validator : AbstractValidator<AddQuizCommand>
    {
        public Validator()
        {
            RuleFor(t => t.UserId).NotNull();
            RuleFor(t => t.Title).NotNull();
            RuleFor(t => t.Tags).NotNull();

            RuleForEach(t => t.Tags)
                .ChildRules(tags => { tags.RuleFor(t => t.Text).NotNull(); });

            When(t => t.QuizTypeEnum == Domain.Quiz.QuizType.QuizTypeEnum.Text || t.QuizTypeEnum == Domain.Quiz.QuizType.QuizTypeEnum.Emoji,
                () => RuleFor(t => t.Text).NotNull());
            
            When(t => t.QuizTypeEnum == Domain.Quiz.QuizType.QuizTypeEnum.Image,
                () => RuleFor(t => t.Image).NotNull());
            When(t => t.QuizTypeEnum == Domain.Quiz.QuizType.QuizTypeEnum.Image,
                () => RuleFor(t => t.ImageType).NotNull());
        }
    }
}