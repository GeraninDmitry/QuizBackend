using Domain;

namespace ArtQuiz.Domain.Quiz;

public class QuizType : SingleValueObject<QuizType.QuizTypeEnum> 
{
    public static QuizType Undefined => new(QuizTypeEnum.Undefined);
    public static QuizType Image => new(QuizTypeEnum.Image);
    public static QuizType Text => new(QuizTypeEnum.Text);
    public static QuizType Emoji => new(QuizTypeEnum.Emoji);
    public static QuizType Ad => new(QuizTypeEnum.Ad);
    public static QuizType ExternalAd => new(QuizTypeEnum.ExternalAd);
    public QuizType(QuizTypeEnum value) : base(value) { }
    
    [Flags]
    public enum QuizTypeEnum
    {
        Undefined = 0,
        Image = 1,
        Text = 2,
        Emoji = 4,
        Ad = 8,
        ExternalAd = 16,
    }
    
    public static QuizType Parse(int value) =>
        new((QuizTypeEnum) value);

    public static implicit operator int(QuizType value) => (int)value.Value;
}