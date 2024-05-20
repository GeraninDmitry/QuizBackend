using ArtQuiz.Application.Enums;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.ChangePasswordCommand;

public sealed partial class ChangePasswordCommand : ICommand<OneOf<
    ChangePasswordCommand.Results.SuccessResult,
    ChangePasswordCommand.Results.ConflictResult,
    ChangePasswordCommand.Results.NotFoundResult
>> {
    public ChangePasswordCommand(string userName, string verificationCode, string newPassword)
    {
        UserName = userName;
        VerificationCode = verificationCode;
        NewPassword = newPassword;
    }

    private string UserName { get; }
    private string VerificationCode { get; }
    private string NewPassword { get; }
   
}