using ArtQuiz.Application.Dto;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddQuizRespectCommand;

public sealed partial class AddQuizRespectCommand : ICommand<OneOf<
    AddQuizRespectCommand.Results.SuccessResult
>>
{
    public AddQuizRespectCommand(string userId, Guid quizId, bool isLiked, bool isDisliked)
    {
        UserId = userId;
        QuizId = quizId;
        IsLiked = isLiked;
        IsDisliked = isDisliked;
    }

    private Guid QuizId { get; set; }
    private string UserId { get; set; }
    private bool IsLiked { get; set; }
    private bool IsDisliked { get; set; }
}