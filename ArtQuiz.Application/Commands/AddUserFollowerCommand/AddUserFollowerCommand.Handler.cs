using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using ArtQuiz.Domain.UserFollower;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace ArtQuiz.Application.Commands.AddUserFollowerCommand;

public sealed partial class AddUserFollowerCommand
{
    internal sealed class Handler : ICommandHandler<AddUserFollowerCommand,
        OneOf<Results.SuccessResult>>
    {
        private readonly IUserFollowersRepository _userFollowerRepository;

        public Handler(IUserFollowersRepository userFollowerRepository)
        {
            _userFollowerRepository = userFollowerRepository;
        }

        public async Task<OneOf<Results.SuccessResult>>
            Handle(AddUserFollowerCommand request, CancellationToken cancellationToken)
        {
            var existFollower = await _userFollowerRepository.FindByUserIdAndFollowedUserId(request.UserId, request.FollowedUserId, cancellationToken);

            if (existFollower != null)
            {
                existFollower.Change(request.IsFollowing);
                await _userFollowerRepository.Save(existFollower);
                
                return Success(existFollower.Id);
            }
            else
            {
                var followerId = new UserFollowerId(Guid.NewGuid());
                var quiz = new UserFollower(followerId, request.UserId, request.FollowedUserId, request.IsFollowing);
                await _userFollowerRepository.Save(quiz);
                
                return Success(followerId);
            }

        }
    }
}