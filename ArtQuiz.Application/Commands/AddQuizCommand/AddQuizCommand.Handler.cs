using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddQuizCommand;

public sealed partial class AddQuizCommand
{
    internal sealed class Handler : ICommandHandler<AddQuizCommand,
        OneOf<Results.SuccessResult, Results.ConflictResult>>
    {
        private readonly IQuizzesRepository _quizzesRepository;
        private readonly IImageService _imageService;

        public Handler(IQuizzesRepository quizzesRepository, IImageService imageService)
        {
            _quizzesRepository = quizzesRepository;
            _imageService = imageService;
        }

        public async Task<OneOf<Results.SuccessResult, Results.ConflictResult>>
            Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            switch (request.QuizTypeEnum)
            {
                case Domain.Quiz.QuizType.QuizTypeEnum.Text:
                case Domain.Quiz.QuizType.QuizTypeEnum.Emoji:
                {
                    var quizId = new QuizId(Guid.NewGuid());

                    var tags = request.Tags
                        .Select(x => new QuizTag(new QuizTagId(Guid.NewGuid()), quizId, x.Text, x.IsTrue))
                        .ToList();

                    var quiz = new Quiz(quizId, request.UserId, new QuizType(request.QuizTypeEnum), new QuizTheme(request.QuizThemeEnum),
                        new ApplicationType(request.ApplicationTypeEnum), new LanguageType(request.LanguageTypeEnum), request.Title, request.Text,
                        tags);

                    await _quizzesRepository.Save(quiz);

                    return Success(quizId);
                }
                case Domain.Quiz.QuizType.QuizTypeEnum.Image:
                {
                    var imagePath = await _imageService.SaveQuizImage(request.Image, request.ImageType, request.ApplicationTypeEnum, request.LanguageTypeEnum);
                    
                    var quizId = new QuizId(Guid.NewGuid());

                    var tags = request.Tags
                        .Select(x => new QuizTag(new QuizTagId(Guid.NewGuid()), quizId, x.Text, x.IsTrue))
                        .ToList();

                    var quiz = new Quiz(quizId, request.UserId, request.Title, imagePath, new QuizType(request.QuizTypeEnum),
                        new QuizTheme(request.QuizThemeEnum), new ApplicationType(request.ApplicationTypeEnum),
                        new LanguageType(request.LanguageTypeEnum), tags);

                    await _quizzesRepository.Save(quiz);

                    return Success(quizId);
                    break;
                }
                case QuizType.QuizTypeEnum.Undefined:
                    throw new InvalidOperationException("Quiz type cannot be undefined");
                case QuizType.QuizTypeEnum.Ad:
                    throw new InvalidOperationException("Quiz type cannot be ad");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}