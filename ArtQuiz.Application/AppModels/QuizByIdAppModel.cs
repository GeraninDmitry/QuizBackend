namespace ArtQuiz.Application.AppModels;

public class QuizByIdAppModel
{
    public QuizAppModel Quiz { get; set; }
    public QuizTagAppModel[] Tags { get; set; }
    public QuizRespectAppModel Respect { get; set; }
}