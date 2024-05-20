using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetSubscriptionsQuery;

public sealed partial class GetSubscriptionsQuery
{
    public sealed class Validator : AbstractValidator<GetSubscriptionsQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
        }
    }
}