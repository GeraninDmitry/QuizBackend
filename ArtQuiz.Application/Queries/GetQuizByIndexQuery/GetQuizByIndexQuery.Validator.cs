using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetQuizByIndexQuery;

public sealed partial class GetQuizByIndexQuery
{
    public sealed class Validator : AbstractValidator<GetQuizByIndexQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
        }
    }
}