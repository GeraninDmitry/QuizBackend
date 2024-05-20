using ArtQuiz.Application.Queries.GetApiKeyByUserQuery;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.UserApiKeys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Commands.CreateUserApiKeyCommand;

public sealed partial class CreateUserApiKeyCommand {
    internal sealed class Handler : ICommandHandler<CreateUserApiKeyCommand,
        OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>> {
        
        private readonly IUserApiKeysRepository _userApiKeysRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IQueryExecutor _queryExecutor;

        public Handler(IUserApiKeysRepository userApiKeysRepository,
            UserManager<IdentityUser> userManager,
            IQueryExecutor queryExecutor)
        {
            _userApiKeysRepository = userApiKeysRepository;
            _userManager = userManager;
            _queryExecutor = queryExecutor;
        }

        public async Task<OneOf<Results.SuccessResult, Results.ConflictResult, Results.NotFoundResult>>
            Handle(CreateUserApiKeyCommand request, CancellationToken cancellationToken) {
            
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return NotFound("User not found");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            
            if (!isPasswordValid)
                return Conflict("Invalid password");
            
            var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            
            if (!isEmailConfirmed)
                return Conflict("Email not confirmed");

            var key = await (await _queryExecutor.Execute(new GetApiKeyByUserQuery(user.Id), cancellationToken))
                .Match(
                    async success => await ValueTask.FromResult(success.Value),
                    async notFound =>
                    {
                        var key = GenerateApiKeyValue();
                        var userApiKey = new UserApiKey(new UserApiKeyId(Guid.NewGuid()), key, user.Id);

                        await _userApiKeysRepository.Save(userApiKey);

                        return key;
                    }
                );

            return Success(key);
        }
        
        private string GenerateApiKeyValue()
        {
            var str = $"{Guid.NewGuid().ToString()}";
            str = str.Replace('-', '1');
            var str2 = GenerateRandomString(10);

            var str3 = $"{str}{str2}";
            
            return str3;
        }
        
        private string GenerateRandomString(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
        
            var result = new char[length];
        
            for (int i = 0; i < length; i++)
                result[i] = characters[random.Next(characters.Length)];

            return new string(result);
        }
    }
}