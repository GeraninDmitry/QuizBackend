using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.SearchUsersByNameQuery
{
    public sealed partial class SearchUserByNameQuery
    {
        private static Results.SuccessResult Success(SearchUserByNameAppModel[] users) => new(users);
        private static Results.NotFoundResult NotFound() => new();

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(SearchUserByNameAppModel[] users) => Users = users; public SearchUserByNameAppModel[] Users { get; } }
            public sealed class NotFoundResult { public NotFoundResult(){} }
        }
    }
}
