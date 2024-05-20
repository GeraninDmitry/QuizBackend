using ArtQuiz.Application;
using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.Enums;
using ArtQuiz.Application.Models;
using ArtQuiz.Application.ReadModels.Models;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using Dapper;

namespace ArtQuiz.Infrastructure.Storage;

public sealed class DefaultDataStorage : DataStorageBase, IDataStorage
{
    public DefaultDataStorage(string connectionString) : base(connectionString)
    {
    }

    public async Task<RandomQuizDataModel> GetRandomQuiz(CancellationToken cancellationToken, QuizSearchType searchType,
        QuizType.QuizTypeEnum typeFlag,
        QuizTheme.QuizThemeEnum themeFlag, ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum,
        string userId, bool isNewQuiz, bool isSubscribed, decimal? percentile = null, DateTime? date = null)
    {
        switch (searchType)
        {
            case QuizSearchType.Undefined:
            {
                throw new InvalidOperationException("Search type cannot be undefined");
            }
            case QuizSearchType.BestAllTime:
            case QuizSearchType.PopularAllTime:
            case QuizSearchType.HotLastMonth:
            {
                await using var connection = await OpenAsync(cancellationToken);

                var query = GetMultipleSqlQuery("GetRandomQuizByPercentile", "GetQuizRespectByQuizTempTable");

                await using var reader = await connection.QueryMultipleAsync(
                    query,
                    new
                    {
                        percentile = percentile,
                        type = typeFlag,
                        theme = themeFlag,
                        applicationType = applicationTypeEnum,
                        languageType = languageTypeEnum,
                        isNewQuiz = isNewQuiz == false ? null : (bool?)isNewQuiz,
                        userId = userId,
                        isSubscribed = isSubscribed == false ? null : (bool?)isSubscribed,
                        date = date ?? DateTime.MinValue,
                        isUseDate = date != null
                    });

                var quiz = await reader.ReadFirstOrDefaultAsync<QuizDataModel>();
                var tags = (await reader.ReadAsync<QuizTagDataModel>()).ToArray();
                var user = await reader.ReadFirstOrDefaultAsync<UserDataModel>();
                var currentUserRespect = await reader.ReadFirstOrDefaultAsync<CurrentUserRespectDataModel>();
                var respect = await reader.ReadFirstOrDefaultAsync<QuizRespectDataModel>();

                return new RandomQuizDataModel()
                {
                    Quiz = quiz,
                    Tags = tags,
                    User = user,
                    Respect = respect,
                    CurrentUserRespect = currentUserRespect
                };
            }
            case QuizSearchType.Latest:
            {
                await using var connection = await OpenAsync(cancellationToken);

                var query = GetMultipleSqlQuery("GetLatestQuiz", "GetQuizRespectByQuizTempTable");

                await using var reader = await connection.QueryMultipleAsync(
                    query,
                    new
                    {
                        type = typeFlag,
                        theme = themeFlag,
                        applicationType = applicationTypeEnum,
                        languageType = languageTypeEnum,
                        isNewQuiz = isNewQuiz == false ? null : (bool?)isNewQuiz,
                        userId = userId,
                        isSubscribed = isSubscribed == false ? null : (bool?)isSubscribed,
                    });

                var quiz = await reader.ReadFirstOrDefaultAsync<QuizDataModel>();
                var tags = (await reader.ReadAsync<QuizTagDataModel>()).ToArray();
                var user = await reader.ReadFirstOrDefaultAsync<UserDataModel>();
                var currentUserRespect = await reader.ReadFirstOrDefaultAsync<CurrentUserRespectDataModel>();
                var respect = await reader.ReadFirstOrDefaultAsync<QuizRespectDataModel>();

                return new RandomQuizDataModel()
                {
                    Quiz = quiz,
                    Tags = tags,
                    User = user,
                    Respect = respect,
                    CurrentUserRespect = currentUserRespect
                };
            }
            case QuizSearchType.Random:
            {
                await using var connection = await OpenAsync(cancellationToken);

                var query = GetMultipleSqlQuery("GetRandomQuiz", "GetQuizRespectByQuizTempTable");

                await using var reader = await connection.QueryMultipleAsync(
                    query,
                    new
                    {
                        type = typeFlag,
                        theme = themeFlag,
                        applicationType = applicationTypeEnum,
                        languageType = languageTypeEnum,
                        isNewQuiz = isNewQuiz == false ? null : (bool?)isNewQuiz,
                        userId = userId,
                        isSubscribed = isSubscribed == false ? null : (bool?)isSubscribed,
                    });

                var quiz = await reader.ReadFirstOrDefaultAsync<QuizDataModel>();
                var tags = (await reader.ReadAsync<QuizTagDataModel>()).ToArray();
                var user = await reader.ReadFirstOrDefaultAsync<UserDataModel>();
                var currentUserRespect = await reader.ReadFirstOrDefaultAsync<CurrentUserRespectDataModel>();
                var respect = await reader.ReadFirstOrDefaultAsync<QuizRespectDataModel>();

                return new RandomQuizDataModel()
                {
                    Quiz = quiz,
                    Tags = tags,
                    User = user,
                    Respect = respect,
                    CurrentUserRespect = currentUserRespect
                };
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(searchType), searchType, null);
        }
    }

    public async Task<decimal> GetRespectPercentileValue(CancellationToken cancellationToken, decimal percentile, QuizType.QuizTypeEnum typeFlag,
        QuizTheme.QuizThemeEnum themeFlag, ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum, DateTime? date = null)
    {
        await using var connection = await OpenAsync(cancellationToken);

        var query = GetMultipleSqlQuery("GetRespectPercentileValue");

        await using var reader = await connection.QueryMultipleAsync(
            query,
            new
            {
                percentile = percentile,
                date = date ?? DateTime.MinValue,
                type = typeFlag,
                theme = themeFlag,
                applicationType = applicationTypeEnum,
                languageType = languageTypeEnum,
                isUseDate = date != null
            });

        var percentileValue = await reader.ReadFirstOrDefaultAsync<decimal>();

        return percentileValue;
    }

    public async Task<(QuizDataModel, QuizTagDataModel[], QuizRespectDataModel)> GetQuizById(Guid quizId, string userId,
        CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);

        var query = GetMultipleSqlQuery("GetQuizById", "GetQuizRespectByQuizTempTable");

        await using var reader = await connection.QueryMultipleAsync(
            query,
            new
            {
                quizId = quizId,
                userId = userId
            });

        var quiz = await reader.ReadFirstOrDefaultAsync<QuizDataModel>();
        var tags = (await reader.ReadAsync<QuizTagDataModel>()).ToArray();
        var respect = await reader.ReadFirstOrDefaultAsync<QuizRespectDataModel>();

        return (quiz, tags, respect);
    }

    public async Task<(QuizDataModel, QuizRespectDataModel)> GetQuizByIndex(uint quizIndex, string userId, bool isAuthorized,
        ApplicationTypeEnum applicationType, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);

        var query = GetMultipleSqlQuery("GetQuizByIndex", "GetQuizRespectByQuizTempTable");

        await using var reader = await connection.QueryMultipleAsync(
            query,
            new
            {
                quizIndex = Convert.ToInt32(quizIndex),
                userId = userId,
                isAuthorized = isAuthorized,
                applicationType = applicationType
            });

        var quiz = await reader.ReadFirstOrDefaultAsync<QuizDataModel>();
        var respect = await reader.ReadFirstOrDefaultAsync<QuizRespectDataModel>();

        return (quiz, respect);
    }

    public async Task<UserByIdDataModel> GetUserById(string userId, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);

        var query = GetMultipleSqlQuery("GetUserById");

        await using var reader = await connection.QueryMultipleAsync(
            query,
            new
            {
                userId = userId
            });

        var user = await reader.ReadFirstOrDefaultAsync<UserByIdDataModel>();

        return user;
    }

    public async Task<AdDataModel?> GetRandomAd(CancellationToken cancellationToken, ApplicationTypeEnum applicationType,
        LanguageTypeEnum languageType, string? userId)
    {
        await using var connection = await OpenAsync(cancellationToken);

        var query = GetMultipleSqlQuery("GetRandomAd");

        await using var reader = await connection.QueryMultipleAsync(
            query,
            new
            {
                applicationType = applicationType,
                languageType = languageType,
                date = DateTime.UtcNow,
                isAuth = userId != null,
                userId = userId
            });

        var ad = await reader.ReadFirstOrDefaultAsync<AdDataModel>();

        return ad;
    }
}