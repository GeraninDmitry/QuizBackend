using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.CheckFollowQuery;

public sealed partial class CheckFollowQuery
{
    public sealed class Validator : AbstractValidator<CheckFollowQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.FollowedUserId).NotEmpty();
        }
    }
}