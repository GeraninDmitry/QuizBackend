using Domain;

namespace ArtQuiz.Domain;

public class ApplicationType : SingleValueObject<ApplicationTypeEnum> 
{
    public static ApplicationType AniRiddle => new(ApplicationTypeEnum.AniRiddle);
    
    public ApplicationType(ApplicationTypeEnum value) : base(value) { }
    
    public static ApplicationType Parse(int value) =>
        new((ApplicationTypeEnum) value);

    public static implicit operator int(ApplicationType value) => (int)value.Value;
}

public enum ApplicationTypeEnum
{
    AniRiddle = 1,
    GameRiddle = 2,
    FilmRiddle = 3,
}