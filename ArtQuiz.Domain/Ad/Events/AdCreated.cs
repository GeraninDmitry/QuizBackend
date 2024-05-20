using Domain;

namespace ArtQuiz.Domain.Ad.Events;

public sealed class AdCreated : DomainEvent<Guid, AdId>
{
    public AdCreated(AdId aggregateId, ApplicationType application, LanguageType language, string? title, string? image, string? text,
        DateTime? startDate, DateTime? endDate, bool isRepeating, bool isForAuthorizedUser, bool isActive)
        : base(DomainEventId.New, aggregateId, DomainDateTime.Current)
    {
        Application = application;
        Language = language;
        Title = title;
        Image = image;
        Text = text;
        StartDate = startDate;
        EndDate = endDate;
        IsRepeating = isRepeating;
        IsForAuthorizedUser = isForAuthorizedUser;
        IsActive = isActive;
    }


    public ApplicationType Application { get; private set; }
    public LanguageType Language { get; private set; }
    public string? Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool IsRepeating { get; private set; }
    public bool IsForAuthorizedUser { get; private set; }
    public bool IsActive { get; private set; }
}