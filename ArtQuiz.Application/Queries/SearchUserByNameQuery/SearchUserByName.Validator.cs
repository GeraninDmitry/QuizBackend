using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.SearchUsersByNameQuery;

public sealed partial class SearchUserByNameQuery
{
    public sealed class Validator : AbstractValidator<SearchUserByNameQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserName).NotEmpty();
        }
    }
}