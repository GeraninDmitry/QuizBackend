using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizByIndexQuery
{
    public sealed partial class GetQuizByIndexQuery
    {
        internal sealed class Handler : IQueryHandler<GetQuizByIndexQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IMapper _mapper;
            private readonly IImageService _imageService;

            public Handler(IDataStorage dataStorage, IMapper mapper, IImageService imageService)
            {
                _dataStorage = dataStorage;
                _mapper = mapper;
                _imageService = imageService;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetQuizByIndexQuery request, CancellationToken cancellationToken)
            {
                var (quiz, respect) = await _dataStorage.GetQuizByIndex(request.QuizIndex, request.UserId, request.IsAuthorized,
                    request.ApplicationType, cancellationToken);

                var response = new QuizByIndexAppModel()
                {
                    Quiz = _mapper.Map<QuizAppModel>(quiz),
                    Respect = _mapper.Map<QuizRespectAppModel>(respect),
                };

                if (quiz?.Image != null)
                {
                    var image = _imageService.GetQuizImagePath(quiz?.Image, quiz.Application);
                    response.Quiz.Image = image;
                }

                if (request.IsAuthorized == false && quiz != null && quiz.Status != QuizStatus.QuizStatusEnum.Published)
                    throw new UnauthorizedAccessException();

                return Success(response);
            }
        }
    }
}