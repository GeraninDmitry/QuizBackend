namespace ArtQuiz.Host.Bindings.User;

public class AthUserByIdResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public long SubscriptionsAmount { get; set; }
    public string Image { get; set; }
}