namespace ArtQuiz.Application.Helpers;

public static class AdHelper
{
    public static bool RollAd(int probability)
    {
        var random = new Random();
        var randomNumber = random.Next(1, 101);

        return randomNumber <= probability;
    }
}