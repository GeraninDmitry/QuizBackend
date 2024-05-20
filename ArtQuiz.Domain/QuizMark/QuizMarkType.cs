using Domain;

namespace ArtQuiz.Domain.QuizMark;

public class QuizMarkType : SingleValueObject<QuizMarkType.QuizMarkTypeEnum> 
{
    public static QuizMarkType Undefined => new(QuizMarkTypeEnum.Undefined);
    public static QuizMarkType Watched => new(QuizMarkTypeEnum.Watched);
    public QuizMarkType(QuizMarkTypeEnum value) : base(value) { }
    
    public enum QuizMarkTypeEnum
    {
        Undefined = 0,
        Watched = 1,
        Saved = 2
    }
    
    public static QuizMarkType Parse(int value) =>
        new((QuizMarkTypeEnum) value);

    public static implicit operator int(QuizMarkType value) => (int)value.Value;
}