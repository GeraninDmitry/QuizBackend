using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetRespectPercentileValueQuery
{
    public sealed partial class GetRespectPercentileValueQuery
    {
        private static Results.SuccessResult Success(decimal value) => new(value);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(decimal value) => Value = value; public decimal Value { get; } }
        }
    }
}
