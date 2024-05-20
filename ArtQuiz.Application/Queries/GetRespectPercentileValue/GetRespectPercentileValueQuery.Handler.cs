using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetRespectPercentileValueQuery
{
    public sealed partial class GetRespectPercentileValueQuery
    {
        internal sealed class Handler : IQueryHandler<GetRespectPercentileValueQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IMemoryCache _memoryCache;

            public Handler(IDataStorage dataStorage,
                IMemoryCache memoryCache)
            {
                _dataStorage = dataStorage;
                _memoryCache = memoryCache;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetRespectPercentileValueQuery request, CancellationToken cancellationToken)
            {
                var cacheKey =
                    $"{nameof(GetRespectPercentileValueQuery)}.{request.Percentile}.{request.TypeFlag}.{request.ThemeFlag}" +
                    $".{request.ApplicationTypeEnum}.{request.LanguageTypeEnum}.{request.Date}";

                if (!_memoryCache.TryGetValue(cacheKey, out decimal percentileValue))
                {
                    percentileValue = await _dataStorage.GetRespectPercentileValue(cancellationToken, request.Percentile, request.TypeFlag,
                        request.ThemeFlag, request.ApplicationTypeEnum, request.LanguageTypeEnum, request.Date);

                    _memoryCache.Set(cacheKey, percentileValue, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
                }

                return Success(percentileValue);
            }
        }
    }
}