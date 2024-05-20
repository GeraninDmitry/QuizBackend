using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.SendVerificationCodeCommand;

public sealed partial class SendVerificationCodeCommand : ICommand<OneOf<
    SendVerificationCodeCommand.Results.SuccessResult,
    SendVerificationCodeCommand.Results.NotFoundResult
>> {
    public SendVerificationCodeCommand(string userName, LanguageTypeEnum language, ApplicationTypeEnum applicationTypeEnum)
    {
        UserName = userName;
        Language = language;
        ApplicationTypeEnum = applicationTypeEnum;
    }

    private string UserName { get; }
    private LanguageTypeEnum Language { get; }
    private ApplicationTypeEnum ApplicationTypeEnum { get; }
   
}