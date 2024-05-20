using Domain;

namespace ArtQuiz.Domain.Quiz;


public class QuizStatus : SingleValueObject<QuizStatus.QuizStatusEnum> 
{
    public static QuizStatus Undefined => new(QuizStatusEnum.Undefined);
    public static QuizStatus InProgress => new(QuizStatusEnum.InProgress);
    public static QuizStatus Published => new(QuizStatusEnum.Published);
    public static QuizStatus Rejected => new(QuizStatusEnum.Rejected);
    public QuizStatus(QuizStatusEnum value) : base(value) { }
    
    public enum QuizStatusEnum
    {
        Undefined = 0,
        InProgress = 1,
        Published = 2,
        Rejected = 3
    }
    
    public static QuizStatus Parse(int value) =>
        new((QuizStatusEnum) value);

    public static implicit operator int(QuizStatus value) => (int)value.Value;
}