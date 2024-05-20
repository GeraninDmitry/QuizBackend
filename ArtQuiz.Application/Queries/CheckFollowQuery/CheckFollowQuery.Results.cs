using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.CheckFollowQuery
{
    public sealed partial class CheckFollowQuery
    {
        private static Results.SuccessResult Success(bool isFollowed) => new(isFollowed);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(bool isFollowed) => IsFollowed = isFollowed; public bool IsFollowed { get; } }
        }
    }
}
