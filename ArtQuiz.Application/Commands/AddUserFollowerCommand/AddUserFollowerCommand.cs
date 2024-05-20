using ArtQuiz.Application.Dto;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddUserFollowerCommand;

public sealed partial class AddUserFollowerCommand : ICommand<OneOf<
    AddUserFollowerCommand.Results.SuccessResult
>>
{
    public AddUserFollowerCommand(string userId, string followedUserId, bool isFollowing)
    {
        UserId = userId;
        FollowedUserId = followedUserId;
        IsFollowing = isFollowing;
    }

    private string UserId { get; set; }
    private string FollowedUserId { get; set; }
    private bool IsFollowing { get; set; }
}