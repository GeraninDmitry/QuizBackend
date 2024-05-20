using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetAdProbabilityQuery
{
    public sealed partial class GetAdProbabilityQuery
    {
        private static Results.SuccessResult Success(int value) => new(value);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(int value) => Value = value; public int Value { get; } }
        }
    }
}
