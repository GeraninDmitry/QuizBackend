using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class AdLogModel
{
    public Guid AdLogId { get; private set; }
    public Guid AdId { get; private set; }

    public string? UserId { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public IdentityUser User { get; private set; }
    public AdModel Ad { get; private set; }
}