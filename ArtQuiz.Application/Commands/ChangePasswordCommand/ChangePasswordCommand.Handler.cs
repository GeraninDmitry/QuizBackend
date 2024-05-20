using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.ChangePasswordCommand;

public sealed partial class ChangePasswordCommand
{
    internal sealed class Handler : ICommandHandler<ChangePasswordCommand,
        OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVerificationService _verificationService;

        public Handler(UserManager<IdentityUser> userManager,
            IVerificationService verificationService)
        {
            _userManager = userManager;
            _verificationService = verificationService;
        }

        public async Task<OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>>
            Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return NotFound("User not found");

            var isSuccess = await _userManager.VerifyUserTokenAsync(user, "Custom",
                "verification_code", request.VerificationCode);

            if (isSuccess)
            {
                var result = await _userManager.ResetPasswordAsync(user, request.VerificationCode, request.NewPassword);

                if (!result.Succeeded)
                    return Conflict("Password could not be changed");

                return Success();
            }
            else
                return Conflict("Verification code is not valid");
        }
    }
}