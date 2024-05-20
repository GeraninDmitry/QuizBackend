namespace ArtQuiz.Application.Models;

public class AdDataModel
{
    public Guid AdId { get; private set; }
    public string Title { get; private set; }
    public string? Image { get; private set; }
    public string? Text { get; private set; }
}