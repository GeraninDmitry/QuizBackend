using ArtQuiz.Domain;

namespace ArtQuiz.Application.ReadModels.Models;

public class AdModel
{
    public Guid AdId { get; private set; }

    public ApplicationTypeEnum Application { get; private set; }
    public LanguageTypeEnum Language { get; private set; }

    public string? Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }

    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public bool IsRepeating { get; private set; }
    public bool IsForAuthorizedUser { get; private set; }
    public bool IsActive { get; private set; }

    public DateTime CreatedOn { get; private set; }
}