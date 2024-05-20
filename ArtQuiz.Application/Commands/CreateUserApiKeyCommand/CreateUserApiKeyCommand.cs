using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.CreateUserApiKeyCommand;

public sealed partial class CreateUserApiKeyCommand : ICommand<OneOf<
    CreateUserApiKeyCommand.Results.SuccessResult,
    CreateUserApiKeyCommand.Results.ConflictResult,
    CreateUserApiKeyCommand.Results.NotFoundResult
>> {
    public CreateUserApiKeyCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    private string UserName { get; set; }
    private string Password { get; set; }
}