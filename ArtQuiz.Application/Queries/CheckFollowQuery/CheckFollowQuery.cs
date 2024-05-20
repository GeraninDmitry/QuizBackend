using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.CheckFollowQuery
{
    public sealed partial class CheckFollowQuery : IQuery<OneOf<
        CheckFollowQuery.Results.SuccessResult>>
    {
        public CheckFollowQuery(string userId, string followedUserId)
        {
            UserId = userId;
            FollowedUserId = followedUserId;
        }

        private string UserId { get; set; }
        private string FollowedUserId { get; set; }
    }
}