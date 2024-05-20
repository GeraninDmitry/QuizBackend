using ArtQuiz.Application.Enums;
using ArtQuiz.Domain.Quiz;
using FluentValidation;

namespace ArtQuiz.Application.Queries.CheckFollowQuery;

public sealed partial class GetAdProbabilityQuery
{
    public sealed class Validator : AbstractValidator<GetAdProbabilityQuery>
    {
        public Validator()
        {
            
        }
    }
}