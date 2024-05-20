namespace ArtQuiz.Host.Bindings.Quiz;

public class AthQuizByIdResponse
{
    public QuizResponse Quiz { get; set; }
    public QuizTagResponse[] Tags { get; set; }
    public QuizRespectResponse Respect { get; set; }
}
