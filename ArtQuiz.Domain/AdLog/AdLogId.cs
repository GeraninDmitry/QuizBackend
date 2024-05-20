using Domain;

namespace ArtQuiz.Domain.AdLog;

public class AdLogId : AggregateRootId<Guid, AdLogId>
{
    public AdLogId(Guid value) : base(value) { }

    public static AdLogId Parse(string value) => new AdLogId(Guid.Parse(value));
    public static implicit operator string(AdLogId state) => state.Value.ToString();
}