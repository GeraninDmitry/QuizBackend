using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace ArtQuiz.Application.Commands.AddQuizMarkCommand;

public sealed partial class AddQuizMarkCommand
{
    internal sealed class Handler : ICommandHandler<AddQuizMarkCommand,
        OneOf<Results.SuccessResult>>
    {
        private readonly IQuizMarksRepository _quizMarksRepository;

        public Handler(IQuizMarksRepository quizMarksRepository)
        {
            _quizMarksRepository = quizMarksRepository;
        }

        public async Task<OneOf<Results.SuccessResult>>
            Handle(AddQuizMarkCommand request, CancellationToken cancellationToken)
        {
            var existMark = await _quizMarksRepository.FindByUserIdAndQuizIdAndType(request.UserId, new QuizId(request.QuizId),
                new QuizMarkType(request.Type), cancellationToken);

            if (existMark != null)
            {
                existMark.ChangeActiveStatus(request.IsActive);
                await _quizMarksRepository.Save(existMark);
                
                return Success(existMark.Id.Value);
            }
            else
            {
                var quizMarkId = new QuizMarkId(Guid.NewGuid());
                var quiz = new QuizMark(quizMarkId, request.UserId, new QuizId(request.QuizId), new QuizMarkType(request.Type), request.IsActive);
                await _quizMarksRepository.Save(quiz);

                return Success(quizMarkId.Value);
            }
        }
    }
}