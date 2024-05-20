using ArtQuiz.Application.Dto;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.AddQuizCommand;

public sealed partial class AddQuizCommand : ICommand<OneOf<
    AddQuizCommand.Results.SuccessResult,
    AddQuizCommand.Results.ConflictResult
>>
{
    public AddQuizCommand(string userId, QuizType.QuizTypeEnum quizTypeEnum, QuizTheme.QuizThemeEnum quizThemeEnum,
        ApplicationTypeEnum applicationTypeEnum, LanguageTypeEnum languageTypeEnum, string title, string image, string imageType, string text,
        ICollection<QuizTagDto> tags)
    {
        UserId = userId;
        QuizTypeEnum = quizTypeEnum;
        Title = title;
        Image = image;
        Text = text;
        Tags = tags;
        ImageType = imageType;
        ApplicationTypeEnum = applicationTypeEnum;
        LanguageTypeEnum = languageTypeEnum;
        QuizThemeEnum = quizThemeEnum;
    }

    private string UserId { get; set; }

    private QuizType.QuizTypeEnum QuizTypeEnum { get; set; }
    private QuizTheme.QuizThemeEnum QuizThemeEnum { get; set; }
    private ApplicationTypeEnum ApplicationTypeEnum { get; set; }
    private LanguageTypeEnum LanguageTypeEnum { get; set; }

    private string Title { get; set; }
    private string Image { get; set; }
    private string ImageType { get; set; }
    private string Text { get; set; }

    private ICollection<QuizTagDto> Tags { get; set; }
}