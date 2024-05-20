using ArtQuiz.Application.Queries.GetApiKeyByUserQuery;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.UserApiKeys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.ConfirmUserCommand;

public sealed partial class ConfirmUserCommand
{
    internal sealed class Handler : ICommandHandler<ConfirmUserCommand,
        OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>>
    {
        private readonly IUserApiKeysRepository _userApiKeysRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IVerificationService _verificationService;

        public Handler(IUserApiKeysRepository userApiKeysRepository,
            UserManager<IdentityUser> userManager,
            IQueryExecutor queryExecutor,
            IVerificationService verificationService)
        {
            _userApiKeysRepository = userApiKeysRepository;
            _userManager = userManager;
            _queryExecutor = queryExecutor;
            _verificationService = verificationService;
        }

        public async Task<OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>>
            Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return NotFound("User not found");

            var isSuccess = await _userManager.VerifyUserTokenAsync(user, "Custom",
                "verification_code", request.VerificationCode);

            if (isSuccess)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return Success();
            }
            else
                return Conflict("Verification code is not valid");
        }
    }
}