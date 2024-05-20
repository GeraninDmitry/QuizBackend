using System.Security.Claims;
using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.Commands.AddAdLogCommand;
using ArtQuiz.Application.Commands.AddQuizMarkCommand;
using ArtQuiz.Application.Enums;
using ArtQuiz.Application.Helpers;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetRandomQuizQuery
{
    public sealed partial class GetRandomQuizQuery
    {
        internal sealed class Handler : IQueryHandler<GetRandomQuizQuery,
            OneOf<Results.SuccessResult, Results.NotFoundResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IQueryExecutor _queryExecutor;
            private readonly IMapper _mapper;
            private readonly ICommandExecutor _commandExecutor;
            private readonly IImageService _imageService;

            public Handler(IDataStorage dataStorage, IQueryExecutor queryExecutor, IMapper mapper,
                ICommandExecutor commandExecutor, IImageService imageService)
            {
                _dataStorage = dataStorage;
                _queryExecutor = queryExecutor;
                _mapper = mapper;
                _commandExecutor = commandExecutor;
                _imageService = imageService;
            }

            public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult>>
                Handle(GetRandomQuizQuery request, CancellationToken cancellationToken)
            {
                var isAd = await IsAd(cancellationToken);
                if (isAd)
                {
                    var ad = await _dataStorage.GetRandomAd(cancellationToken, request.ApplicationTypeEnum, request.LanguageTypeEnum, request.UserId);
                    
                    if (ad != null)
                    {
                        await _commandExecutor.Execute(new AddAdLogCommand(request.UserId, ad.AdId), cancellationToken);

                        //todo: установить путь для изображения
                        var adAppModel = new RandomQuizAppModel()
                        {
                            Quiz = new QuizAppModel()
                            {
                                QuizId = ad.AdId,
                                Title = ad.Title,
                                Image = ad.Image,
                                Text =  ad.Text,
                                Type =  QuizType.QuizTypeEnum.Ad,
                            }
                        };
                        return Success(adAppModel);
                    }
                }

                decimal percentileValue = 0;
                decimal percentile = 0;
                DateTime? dateTime = null;
                switch (request.SearchType)
                {
                    case QuizSearchType.BestAllTime:
                    case QuizSearchType.PopularAllTime:
                    case QuizSearchType.HotLastMonth:
                    {
                        switch (request.SearchType)
                        {
                            case QuizSearchType.BestAllTime:
                                percentile = PercentileHelper.BestAllTimePercentile;
                                break;
                            case QuizSearchType.PopularAllTime:
                                percentile = PercentileHelper.PopularAllTimePercentile;
                                break;
                            case QuizSearchType.HotLastMonth:
                                percentile = PercentileHelper.HotLastMonthPercentile;
                                dateTime = DateTime.Today.AddMonths(-1);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        
                        percentileValue = await GetPercentileValue(request, cancellationToken, percentile, dateTime);
                        break;
                    }
                    case QuizSearchType.Latest:
                    case QuizSearchType.Random:
                        break;
                    case QuizSearchType.Undefined:
                        throw new InvalidOperationException("Search type cannot be undefined");
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var quiz = await _dataStorage.GetRandomQuiz(cancellationToken, request.SearchType, request.TypeFlag,
                    request.ThemeFlag, request.ApplicationTypeEnum, request.LanguageTypeEnum, request.UserId, request.IsNewQuiz,
                    request.IsSubscribed, percentileValue, dateTime);

                if (request.UserId != null && quiz.Quiz != null)
                {
                    await _commandExecutor.Execute(
                        new AddQuizMarkCommand(request.UserId, QuizMarkType.QuizMarkTypeEnum.Watched, quiz.Quiz.QuizId, true),
                        cancellationToken);
                }

                if (quiz?.Quiz == null)
                    return NotFound("Quiz not found");

                var appModel = _mapper.Map<RandomQuizAppModel>(quiz);

                if (quiz?.Quiz?.Image != null)
                {
                    var image = _imageService.GetQuizImagePath(quiz?.Quiz?.Image, request.ApplicationTypeEnum);
                    appModel.Quiz.Image = image;
                }
                
                if (quiz?.User?.UserImage != null)
                {
                    var image = _imageService.GetAvatarPath(quiz.User.UserImage);
                    appModel.User.UserImage = image;
                }

                return Success(appModel);
            }

            private async Task<decimal> GetPercentileValue(GetRandomQuizQuery request, CancellationToken cancellationToken,
                decimal percentile, DateTime? dateTime)
            {
                return (await _queryExecutor
                        .Execute(new GetRespectPercentileValueQuery.GetRespectPercentileValueQuery(percentile, dateTime,
                                request.TypeFlag, request.ThemeFlag, request.ApplicationTypeEnum, request.LanguageTypeEnum),
                            cancellationToken))
                    .Match(success => success.Value);
            }

            private async Task<bool> IsAd(CancellationToken cancellationToken)
            {
                var adProbability = (await _queryExecutor
                    .Execute(new GetAdProbabilityQuery.GetAdProbabilityQuery(), cancellationToken)).Match(success => success.Value);

                var isAd = AdHelper.RollAd(adProbability);
                return isAd;
            }
        }
    }
}