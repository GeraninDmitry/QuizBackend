using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetUserByIdQuery;

public sealed partial class GetUserByIdQuery
{
    public sealed class Validator : AbstractValidator<GetUserByIdQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
        }
    }
}