namespace ArtQuiz.Host.Bindings.Follower;

public class AddFollowUserRequest
{
    public string FollowedUserId { get; set; }
    public bool IsFollowing { get; set; }
}