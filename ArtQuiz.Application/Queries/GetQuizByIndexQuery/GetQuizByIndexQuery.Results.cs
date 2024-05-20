using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetQuizByIndexQuery
{
    public sealed partial class GetQuizByIndexQuery
    {
        private static Results.SuccessResult Success(QuizByIndexAppModel quiz) => new(quiz);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(QuizByIndexAppModel quiz) => Quiz = quiz; public QuizByIndexAppModel Quiz { get; } }
        }
    }
}
