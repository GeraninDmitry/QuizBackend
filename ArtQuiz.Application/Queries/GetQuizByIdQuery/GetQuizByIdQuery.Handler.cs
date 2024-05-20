using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizByIdQuery
{
    public sealed partial class GetQuizByIdQuery
    {
        internal sealed class Handler : IQueryHandler<GetQuizByIdQuery,
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
                Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
            {
                var (quiz, tags, respect) = await _dataStorage.GetQuizById(request.QuizId, request.UserId, cancellationToken);

                var response = new QuizByIdAppModel()
                {
                    Quiz = _mapper.Map<QuizAppModel>(quiz),
                    Respect = _mapper.Map<QuizRespectAppModel>(respect),
                    Tags = tags.Select(i => _mapper.Map<QuizTagAppModel>(i)).ToArray()
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