using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.SendVerificationCodeCommand;

public sealed partial class SendVerificationCodeCommand
{
    internal sealed class Handler : ICommandHandler<SendVerificationCodeCommand,
        OneOf<Results.SuccessResult, Results.NotFoundResult>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVerificationService _verificationService;

        public Handler(UserManager<IdentityUser> userManager,
            IVerificationService verificationService)
        {
            _userManager = userManager;
            _verificationService = verificationService;
        }

        public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult>>
            Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            if(user == null)
                return NotFound("User not found");
            
            await _verificationService.GenerateAndSendVerificationCode(request.UserName, request.Language, request.ApplicationTypeEnum);

            return Success();
        }
    }
}