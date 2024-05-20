namespace ArtQuiz.Host.Bindings.User;

public class UserByIdResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public long SubscriptionsAmount { get; set; }
    public string Image { get; set; }
}