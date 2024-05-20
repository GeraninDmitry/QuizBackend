namespace ArtQuiz.Application.Models;

public class UserByIdDataModel
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public long SubscriptionsAmount { get; private set; }
    public string? Image { get; private set; }
}