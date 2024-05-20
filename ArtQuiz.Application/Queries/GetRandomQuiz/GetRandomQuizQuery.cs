using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetRandomQuizQuery
{
    public sealed partial class GetRandomQuizQuery : IQuery<OneOf<
        GetRandomQuizQuery.Results.SuccessResult,
        GetRandomQuizQuery.Results.NotFoundResult>>
    {
        public GetRandomQuizQuery(QuizSearchType searchType, QuizType.QuizTypeEnum typeFlag, QuizTheme.QuizThemeEnum themeFlag,
            ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum, string userId, bool isNewQuiz, bool isSubscribed)
        {
            SearchType = searchType;
            TypeFlag = typeFlag;
            ThemeFlag = themeFlag;
            UserId = userId;
            IsNewQuiz = isNewQuiz;
            IsSubscribed = isSubscribed;
            ApplicationTypeEnum = applicationTypeEnum;
            LanguageTypeEnum = languageTypeEnum;
        }

        private QuizSearchType SearchType { get; set; }
        private QuizType.QuizTypeEnum TypeFlag { get; set; }
        private QuizTheme.QuizThemeEnum ThemeFlag { get; set; }
        private ApplicationTypeEnum ApplicationTypeEnum { get; set; }
        private LanguageTypeEnum LanguageTypeEnum { get; set; }

        private string? UserId { get; set; }
        private bool IsNewQuiz { get; set; }
        private bool IsSubscribed { get; set; }
    }
}