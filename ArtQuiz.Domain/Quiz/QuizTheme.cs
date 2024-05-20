using Domain;

namespace ArtQuiz.Domain.Quiz;

public class QuizTheme : SingleValueObject<QuizTheme.QuizThemeEnum> 
{
    public static QuizTheme Undefined => new(QuizThemeEnum.Undefined);
    public static QuizTheme Anime => new(QuizThemeEnum.Anime);
    public static QuizTheme Hero => new(QuizThemeEnum.Hero);
    public static QuizTheme Other => new(QuizThemeEnum.Other);
    public QuizTheme(QuizThemeEnum value) : base(value) { }
    
    [Flags]
    public enum QuizThemeEnum
    {
        Undefined = 0,
        Anime = 1,
        Hero = 2,
        Other = 4,
    }
    
    public static QuizTheme Parse(int value) =>
        new((QuizThemeEnum) value);

    public static implicit operator int(QuizTheme value) => (int)value.Value;
}