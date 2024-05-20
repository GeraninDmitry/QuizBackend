using ArtQuiz.Application.ReadModels;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetAdProbabilityQuery
{
    public sealed partial class GetAdProbabilityQuery
    {
        internal sealed class Handler : IQueryHandler<GetAdProbabilityQuery, OneOf<Results.SuccessResult>>
        {
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;
            private readonly IMemoryCache _memoryCache;

            public Handler(IReadModel readModel, IReadModelQueryExecutor readModelExecutor, IMemoryCache memoryCache)
            {
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
                _memoryCache = memoryCache;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetAdProbabilityQuery request, CancellationToken cancellationToken)
            {
                var cacheKey = $"{nameof(GetAdProbabilityQuery)}";
                
                if (!_memoryCache.TryGetValue(cacheKey, out int value))
                {
                    var response = await _readModelExecutor.FirstOrDefaultAsync(
                        _readModel.AdSettings
                            .Select(m => new {Value = m.Probability}),
                        cancellationToken);
                    
                    value = response?.Value ?? 0;
                    
                    _memoryCache.Set(cacheKey, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
                }
                
                return Success(value);
            }
        }
    }
}
