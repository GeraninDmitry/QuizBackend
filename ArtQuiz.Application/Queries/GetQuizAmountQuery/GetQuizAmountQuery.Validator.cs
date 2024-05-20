using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetQuizAmountQuery;

public sealed partial class GetQuizAmountQuery
{
    public sealed class Validator : AbstractValidator<GetQuizAmountQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
        }
    }
}