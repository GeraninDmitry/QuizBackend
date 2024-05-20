using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetRandomQuizQuery
{
    public sealed partial class GetRandomQuizQuery
    {
        private static Results.SuccessResult Success(RandomQuizAppModel quiz) => new(quiz);
        private static Results.NotFoundResult NotFound(string message) => new(message);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(RandomQuizAppModel quiz) => Quiz = quiz; public RandomQuizAppModel Quiz { get; } }
            public sealed class NotFoundResult { public NotFoundResult(string message) => Message = message; public string Message { get; } }
        }
    }
}
