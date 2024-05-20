using ArtQuiz.Domain.Ad.Events;
using Domain;

namespace ArtQuiz.Domain.Ad;

public class Ad : AggregateRoot<Guid, AdId>
{
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

    public DateTime CreatedOn { get; private set; }

    private Ad() { }
    
    public Ad(AdId id, ApplicationType application, LanguageType language, string? title, string? image, string? text, DateTime? startDate,
        DateTime? endDate, bool isRepeating, bool isForAuthorizedUser, bool isActive) : base(id)
    {
        ProduceEvent(new AdCreated(id, application, language, title, image, text, startDate, endDate, isRepeating, isForAuthorizedUser, isActive), Apply);
    }

    private void Apply(AdCreated @event)
    {
        CreatedOn = @event.OccurredOn;
        Application = @event.Application;
        Language = @event.Language;
        Title = @event.Title;
        Image = @event.Image;
        Text = @event.Text;
        StartDate = @event.StartDate;
        EndDate = @event.EndDate;
        IsRepeating = @event.IsRepeating;
        IsForAuthorizedUser = @event.IsForAuthorizedUser;
        IsActive = @event.IsActive;
    }
}