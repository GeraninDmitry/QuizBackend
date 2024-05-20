using ArtQuiz.Application.Dto;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddUserAvatarCommand;

public sealed partial class AddUserAvatarCommand : ICommand<OneOf<
    AddUserAvatarCommand.Results.SuccessResult
>>
{
    public AddUserAvatarCommand(string userId, string image, string imageType)
    {
        UserId = userId;
        Image = image;
        ImageType = imageType;
    }

    private string UserId { get; set; }
    private string Image { get; set; }
    private string ImageType { get; set; }
}