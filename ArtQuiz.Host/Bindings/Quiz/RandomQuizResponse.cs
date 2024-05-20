namespace ArtQuiz.Host.Bindings.Quiz;

public class RandomQuizResponse
{
    public QuizResponse Quiz { get; set; }
    public QuizTagResponse[] Tags { get; set; }
    public UserResponse User { get; set; }
    public QuizRespectResponse Respect { get; set; }
    public CurrentUserRespectResponse CurrentUserRespect { get; set; }
}