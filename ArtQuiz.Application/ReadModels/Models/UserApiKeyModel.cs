using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class UserApiKeyModel
{
    public Guid UserApiKeyId { get; private set; }
    public string Value { get; private set; }
    public string UserId { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public long Version { get; private set; }

    public IdentityUser User { get; private set; }
}