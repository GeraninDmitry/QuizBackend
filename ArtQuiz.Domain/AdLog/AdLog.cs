using ArtQuiz.Domain.Ad;
using ArtQuiz.Domain.AdLog.Events;
using Domain;

namespace ArtQuiz.Domain.AdLog;

public class AdLog : AggregateRoot<Guid, AdLogId>
{
    public string? UserId { get; private set; }
    public AdId AdId { get; private set; }

    public DateTime CreatedOn { get; private set; }

    private AdLog()
    {
    }

    public AdLog(AdLogId id, AdId adId, string? userId) : base(id)
    {
        ProduceEvent(new AdLogCreated(id, adId, userId), Apply);
    }

    private void Apply(AdLogCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        UserId = @event.UserId;
        AdId = @event.AdId;
    }
}