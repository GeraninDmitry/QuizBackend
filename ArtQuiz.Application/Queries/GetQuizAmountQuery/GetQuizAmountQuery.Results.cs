using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetQuizAmountQuery
{
    public sealed partial class GetQuizAmountQuery
    {
        private static Results.SuccessResult Success(ulong amount) => new(amount);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(ulong amount) => Amount = amount; public ulong Amount { get; } }
        }
    }
}
