using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.CreateUserCommand;

public sealed partial class CreateUserCommand : ICommand<OneOf<
    CreateUserCommand.Results.SuccessResult,
    CreateUserCommand.Results.ConflictResult
>> {
    public CreateUserCommand(string userName, string password, string email, LanguageTypeEnum language, ApplicationTypeEnum applicationTypeEnum)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Language = language;
        ApplicationTypeEnum = applicationTypeEnum;
    }

    private string UserName { get; set; }
    private string Password { get; set; }
    private string Email { get; set; }
    private LanguageTypeEnum Language { get; set; }
    private ApplicationTypeEnum ApplicationTypeEnum { get; set; }
}