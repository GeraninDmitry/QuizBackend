using ArtQuiz.Domain.Ad;
using Domain;

namespace ArtQuiz.Domain.AdLog.Events;

public sealed class AdLogCreated : DomainEvent<Guid, AdLogId>
{
    public AdLogCreated(AdLogId aggregateId, AdId adId, string? userId)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        AdId = adId;
        UserId = userId;
    }

    public AdId AdId { get; private set; }
    public string? UserId { get; private set; }
}