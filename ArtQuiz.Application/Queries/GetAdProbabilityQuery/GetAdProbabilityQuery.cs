using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetAdProbabilityQuery
{
    public sealed partial class GetAdProbabilityQuery : IQuery<OneOf<
        GetAdProbabilityQuery.Results.SuccessResult>>
    {
        public GetAdProbabilityQuery() {}

    }
}
