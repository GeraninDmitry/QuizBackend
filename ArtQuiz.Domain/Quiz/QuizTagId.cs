using Domain;

namespace ArtQuiz.Domain.Quiz;

public sealed class QuizTagId : Identity<Guid, QuizTagId> {
    public QuizTagId(Guid value) : base(value) { }

    public static QuizTagId Parse(string value) => new QuizTagId(Guid.Parse(value));
    public static implicit operator string(QuizTagId state) => state.Value.ToString();
    public static QuizTagId New => new(Guid.NewGuid());
}