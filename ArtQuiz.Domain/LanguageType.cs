using Domain;

namespace ArtQuiz.Domain;

public class LanguageType : SingleValueObject<LanguageTypeEnum> 
{
    public static LanguageType Ru => new(LanguageTypeEnum.Ru);
    
    public LanguageType(LanguageTypeEnum value) : base(value) { }
    
    public static LanguageType Parse(int value) =>
        new((LanguageTypeEnum) value);

    public static implicit operator int(LanguageType value) => (int)value.Value;
}

public enum LanguageTypeEnum
{
    Ru = 1,
    En = 2,
}