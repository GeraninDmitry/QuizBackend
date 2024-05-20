using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;

namespace ArtQuiz.Host.Bindings.Quiz;

public class AddQuizRequest
{
    public QuizType.QuizTypeEnum Type { get; set; }
    public QuizTheme.QuizThemeEnum Theme { get; set; }
    public ApplicationTypeEnum ApplicationType { get; set; }
    public LanguageTypeEnum LanguageType { get; set; }

    public string Title { get; set; }
    public string? Image { get; set; }
    public string? ImageType { get; set; }
    public string? Text { get; set; }
    
    public ICollection<AddQuizTagRequest> Tags { get; set; }
}

public class AddQuizTagRequest
{
    public string Text { get; set; }
    public bool IsTrue { get; set; }
}