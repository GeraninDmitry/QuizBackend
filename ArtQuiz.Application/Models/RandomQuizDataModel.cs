namespace ArtQuiz.Application.Models;

public class RandomQuizDataModel
{
    public QuizDataModel Quiz { get; set; }
    public QuizTagDataModel[] Tags { get; set; }
    public UserDataModel User { get; set; }
    public QuizRespectDataModel Respect { get; set; }
    public CurrentUserRespectDataModel CurrentUserRespect { get; set; }
}