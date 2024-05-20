using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.CreateUserCommand;

public sealed partial class CreateUserCommand
{
    internal sealed class Handler : ICommandHandler<CreateUserCommand,
        OneOf<Results.SuccessResult, Results.ConflictResult>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVerificationService _verificationService;

        public Handler(UserManager<IdentityUser> userManager,
            IVerificationService verificationService)
        {
            _userManager = userManager;
            _verificationService = verificationService;
        }

        public async Task<OneOf<Results.SuccessResult, Results.ConflictResult>>
            Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = request.UserName, Email = request.Email }, request.Password
            );
            
            if (result.Succeeded)
                await _verificationService.GenerateAndSendVerificationCode(request.UserName, request.Language, request.ApplicationTypeEnum);

            return result.Succeeded
                ? Success()
                : Conflict(result.Errors.Select(i => i.Code).FirstOrDefault());
        }
    }
}