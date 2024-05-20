using ArtQuiz.Application.ReadModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetUserByApiKeyQuery
{
    public sealed partial class GetUserByApiKeyQuery
    {
        internal sealed class Handler : IQueryHandler<GetUserByApiKeyQuery, OneOf<Results.SuccessResult, Results.NotFoundResult>>
        {
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;
            private readonly IConfigurationProvider _configurationProvider;
            private readonly IMemoryCache _memoryCache;

            public Handler(IReadModel readModel, IReadModelQueryExecutor readModelExecutor,
                IConfigurationProvider configurationProvider, IMemoryCache memoryCache)
            {
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
                _configurationProvider = configurationProvider;
                _memoryCache = memoryCache;
            }

            public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult>>
                Handle(GetUserByApiKeyQuery request, CancellationToken cancellationToken)
            {
                var cacheKey = $"{nameof(GetUserByApiKeyQuery)}.{request.ApiKeyValue}";
                
                if (!_memoryCache.TryGetValue(cacheKey, out IdentityUser? user))
                {
                    user = await _readModelExecutor.FirstOrDefaultAsync(
                        _readModel.UserApiKeys
                            .Where(m => m.Value == request.ApiKeyValue)
                            .Select(m => m.User),
                        cancellationToken);

                    if (user == null)
                        return NotFound($"User with ID '{request.ApiKeyValue}' not found.");

                    _memoryCache.Set(cacheKey, user, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
                }

                return Success(new UserApiKeyAppModel() { User = user });
            }
        }
    }
}