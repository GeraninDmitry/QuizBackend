using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizRespect;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace ArtQuiz.Application.Commands.AddQuizRespectCommand;

public sealed partial class AddQuizRespectCommand
{
    internal sealed class Handler : ICommandHandler<AddQuizRespectCommand,
        OneOf<Results.SuccessResult>>
    {
        private readonly IQuizRespectRepository _quizRespectsRepository;

        public Handler(IQuizRespectRepository quizRespectsRepository)
        {
            _quizRespectsRepository = quizRespectsRepository;
        }

        public async Task<OneOf<Results.SuccessResult>>
            Handle(AddQuizRespectCommand request, CancellationToken cancellationToken)
        {
            var existRespect = await _quizRespectsRepository.FindByUserIdAndQuizId(request.UserId, new QuizId(request.QuizId), cancellationToken);

            if (existRespect != null)
            {
                existRespect.Change(request.IsLiked, request.IsDisliked);
                await _quizRespectsRepository.Save(existRespect);
                
                return Success(existRespect.Id);
            }
            else
            {
                var respectId = new QuizRespectId(Guid.NewGuid());
                var quiz = new QuizRespect(respectId, request.UserId, new QuizId(request.QuizId), request.IsLiked, request.IsDisliked);
                await _quizRespectsRepository.Save(quiz);
                
                return Success(respectId);
            }

        }
    }
}