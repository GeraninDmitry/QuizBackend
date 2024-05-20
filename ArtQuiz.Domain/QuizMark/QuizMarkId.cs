using Domain;

namespace ArtQuiz.Domain.QuizMark;

public sealed class QuizMarkId : AggregateRootId<Guid, QuizMarkId> {
    public QuizMarkId(Guid value) : base(value) { }

    public static QuizMarkId Parse(string value) => new QuizMarkId(Guid.Parse(value));
    public static implicit operator string(QuizMarkId state) => state.Value.ToString();
}

