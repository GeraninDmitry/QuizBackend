using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using ArtQuiz.Domain.UserFollower;
using ArtQuiz.Domain.UserImage;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace ArtQuiz.Application.Commands.AddUserAvatarCommand;

public sealed partial class AddUserAvatarCommand
{
    internal sealed class Handler : ICommandHandler<AddUserAvatarCommand,
        OneOf<Results.SuccessResult>>
    {
        private readonly IUserImagesRepository _userImagesRepository;
        private readonly IImageService _imageService;

        public Handler(IUserImagesRepository userImagesRepository, IImageService imageService)
        {
            _userImagesRepository = userImagesRepository;
            _imageService = imageService;
        }

        public async Task<OneOf<Results.SuccessResult>>
            Handle(AddUserAvatarCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _imageService.SaveAvatar(request.Image, request.ImageType);

            var existUserImage = await _userImagesRepository.FindByUserId(request.UserId, cancellationToken);

            if (existUserImage != null)
            {
                existUserImage.ChangeImage(imageName);
                await _userImagesRepository.Save(existUserImage);
                
                return Success(existUserImage.Id.Value);
            }
            else
            {
                var userImageId = Guid.NewGuid();
                var userImage = new UserImage(new UserImageId(userImageId), request.UserId, imageName);
                await _userImagesRepository.Save(userImage);
                
                return Success(userImageId);
            }
            
        }
    }
}