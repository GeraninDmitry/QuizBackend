using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.CheckVerificationCodeQuery
{
    public sealed partial class CheckVerificationCodeQuery
    {
        internal sealed class Handler : IQueryHandler<CheckVerificationCodeQuery,
            OneOf<Results.SuccessResult, Results.NotFoundResult, Results.ConflictResult>>
        {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly IVerificationService _verificationService;

            public Handler(UserManager<IdentityUser> userManager, IVerificationService verificationService)
            {
                _userManager = userManager;
                _verificationService = verificationService;
            }

            public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult, Results.ConflictResult>>
                Handle(CheckVerificationCodeQuery request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return NotFound("User not found");

                var isSuccess = await _userManager.VerifyUserTokenAsync(user, "Custom",
                    "verification_code", request.VerificationCode);

                if (isSuccess)
                    return Success();
                else
                    return Conflict("Verification code is not valid");
            }
        }
    }
}