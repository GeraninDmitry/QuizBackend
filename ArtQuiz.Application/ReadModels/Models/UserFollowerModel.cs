using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels.Models;

public class UserFollowerModel
{
    public Guid UserFollowerId { get; private set; }
    public string UserId { get; private set; }
    public string FollowedUserId { get; private set; }
    public bool IsFollowing { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public IdentityUser User { get; private set; }
    public IdentityUser FollowedUser { get; private set; }
}