using ArtQuiz.Application.Dto;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddQuizMarkCommand;

public sealed partial class AddQuizMarkCommand : ICommand<OneOf<
    AddQuizMarkCommand.Results.SuccessResult
>>
{
    public AddQuizMarkCommand(string userId, QuizMarkType.QuizMarkTypeEnum type, Guid quizId, bool isActive)
    {
        UserId = userId;
        Type = type;
        QuizId = quizId;
        IsActive = isActive;
    }

    private Guid QuizId { get; set; }
    private string UserId { get; set; }
    private QuizMarkType.QuizMarkTypeEnum Type { get; set; }
    private bool IsActive { get; set; }
}