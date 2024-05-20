using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetUserByIdQuery
{
    public sealed partial class GetUserByIdQuery
    {
        private static Results.SuccessResult Success(UserByIdAppModel user) => new(user);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(UserByIdAppModel user) => User = user; public UserByIdAppModel User { get; } }
        }
    }
}
