using ArtQuiz.Application.Dto;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddAdLogCommand;

public sealed partial class AddAdLogCommand : ICommand<OneOf<
    AddAdLogCommand.Results.SuccessResult
>>
{
    public AddAdLogCommand(string? userId, Guid adId)
    {
        UserId = userId;
        AdId = adId;
    }

    private string? UserId { get; set; }
    private Guid AdId { get; set; }
}