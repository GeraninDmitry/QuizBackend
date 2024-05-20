namespace ArtQuiz.Application.AppModels;

public class RandomQuizAppModel
{
    public QuizAppModel Quiz { get; set; }
    public QuizTagAppModel[] Tags { get; set; }
    public UserAppModel User { get; set; }
    public QuizRespectAppModel Respect { get; set; }
    public CurrentUserRespectAppModel CurrentUserRespect { get; set; }
}