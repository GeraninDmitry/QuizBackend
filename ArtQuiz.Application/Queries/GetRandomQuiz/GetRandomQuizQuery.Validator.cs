using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetRandomQuizQuery;

public sealed partial class GetRandomQuizQuery
{
    public sealed class Validator : AbstractValidator<GetRandomQuizQuery>
    {
        public Validator()
        {
            RuleFor(t => t.SearchType).NotEqual(QuizSearchType.Undefined);
            RuleFor(t => t.TypeFlag).NotEqual(QuizType.QuizTypeEnum.Undefined);
            RuleFor(t => t.ThemeFlag).NotEqual(QuizTheme.QuizThemeEnum.Undefined);
        }
    }
}