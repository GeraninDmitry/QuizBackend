using Domain;

namespace ArtQuiz.Domain.QuizRespect;

public sealed class QuizRespectId : AggregateRootId<Guid, QuizRespectId> {
    public QuizRespectId(Guid value) : base(value) { }

    public static QuizRespectId Parse(string value) => new QuizRespectId(Guid.Parse(value));
    public static implicit operator string(QuizRespectId state) => state.Value.ToString();
}

