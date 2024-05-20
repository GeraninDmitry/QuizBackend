using Domain;

namespace ArtQuiz.Domain.Ad;

public class AdId : AggregateRootId<Guid, AdId>
{
    public AdId(Guid value) : base(value) { }

    public static AdId Parse(string value) => new AdId(Guid.Parse(value));
    public static implicit operator string(AdId state) => state.Value.ToString();
}