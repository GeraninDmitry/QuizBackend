using ArtQuiz.Application.Enums;
using ArtQuiz.Application.Models;
using ArtQuiz.Application.ReadModels.Models;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;

namespace ArtQuiz.Application.Services.Interface;

public interface IDataStorage
{
    Task<RandomQuizDataModel> GetRandomQuiz(CancellationToken cancellationToken, QuizSearchType searchType, QuizType.QuizTypeEnum typeFlag,
        QuizTheme.QuizThemeEnum themeFlag, ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum, string userId,
        bool isNewQuiz, bool isSubscribed, decimal? percentile = null, DateTime? date = null);

    Task<decimal> GetRespectPercentileValue(CancellationToken cancellationToken, decimal percentile, QuizType.QuizTypeEnum typeFlag,
        QuizTheme.QuizThemeEnum themeFlag, ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum, DateTime? date = null);

    Task<(QuizDataModel, QuizTagDataModel[], QuizRespectDataModel)> GetQuizById(Guid quizId, string userId, CancellationToken cancellationToken);

    Task<(QuizDataModel, QuizRespectDataModel)> GetQuizByIndex(uint quizIndex, string userId, bool isAuthorized, ApplicationTypeEnum applicationType,
        CancellationToken cancellationToken);

    Task<UserByIdDataModel> GetUserById(string userId, CancellationToken cancellationToken);

    Task<AdDataModel?> GetRandomAd(CancellationToken cancellationToken, ApplicationTypeEnum applicationType, LanguageTypeEnum languageType,
        string? userId);
}