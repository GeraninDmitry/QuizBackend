using Domain;

namespace ArtQuiz.Domain.Quiz;

public sealed class QuizId : AggregateRootId<Guid, QuizId> {
    public QuizId(Guid value) : base(value) { }

    public static QuizId Parse(string value) => new QuizId(Guid.Parse(value));
    public static implicit operator string(QuizId state) => state.Value.ToString();
}