using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.GetRespectPercentileValueQuery
{
    public sealed partial class GetRespectPercentileValueQuery : IQuery<OneOf<
        GetRespectPercentileValueQuery.Results.SuccessResult>>
    {
        public GetRespectPercentileValueQuery(decimal percentile, DateTime? date, QuizType.QuizTypeEnum typeFlag,
            QuizTheme.QuizThemeEnum themeFlag, ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum)
        {
            Percentile = percentile;
            Date = date;
            TypeFlag = typeFlag;
            ThemeFlag = themeFlag;
            ApplicationTypeEnum = applicationTypeEnum;
            LanguageTypeEnum = languageTypeEnum;
        }

        private decimal Percentile { get; set; }
        private DateTime? Date { get; set; }
        private QuizType.QuizTypeEnum TypeFlag { get; set;}
        private QuizTheme.QuizThemeEnum ThemeFlag { get; set;}
        private ApplicationTypeEnum ApplicationTypeEnum { get; set; }
        private LanguageTypeEnum LanguageTypeEnum { get; set; }
    }
}