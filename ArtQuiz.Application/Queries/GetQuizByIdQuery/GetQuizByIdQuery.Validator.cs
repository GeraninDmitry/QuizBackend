using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.GetQuizByIdQuery;

public sealed partial class GetQuizByIdQuery
{
    public sealed class Validator : AbstractValidator<GetQuizByIdQuery>
    {
        public Validator()
        {
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.QuizId).NotEmpty();
        }
    }
}