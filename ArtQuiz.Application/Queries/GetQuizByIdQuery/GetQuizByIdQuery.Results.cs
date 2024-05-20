using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetQuizByIdQuery
{
    public sealed partial class GetQuizByIdQuery
    {
        private static Results.SuccessResult Success(QuizByIdAppModel quiz) => new(quiz);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(QuizByIdAppModel quiz) => Quiz = quiz; public QuizByIdAppModel Quiz { get; } }
        }
    }
}
