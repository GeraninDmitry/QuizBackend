using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.ConfirmUserCommand;

public sealed partial class ConfirmUserCommand : ICommand<OneOf<
    ConfirmUserCommand.Results.SuccessResult,
    ConfirmUserCommand.Results.ConflictResult,
    ConfirmUserCommand.Results.NotFoundResult
>> {
    public ConfirmUserCommand(string userName, string verificationCode)
    {
        UserName = userName;
        VerificationCode = verificationCode;
    }

    private string UserName { get; set; }
    private string VerificationCode { get; set; }
}