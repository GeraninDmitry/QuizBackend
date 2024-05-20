using ArtQuiz.Application.ReadModels;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetApiKeyByUserQuery
{
    public sealed partial class GetApiKeyByUserQuery
    {
        internal sealed class Handler : IQueryHandler<GetApiKeyByUserQuery, OneOf<Results.SuccessResult, Results.NotFoundResult>>
        {
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;
            private readonly IConfigurationProvider _configurationProvider;

            public Handler(IReadModel readModel, IReadModelQueryExecutor readModelExecutor,
                IConfigurationProvider configurationProvider)
            {
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
                _configurationProvider = configurationProvider;
            }

            public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult>>
                Handle(GetApiKeyByUserQuery request, CancellationToken cancellationToken)
            {
                var apiKey = await _readModelExecutor.FirstOrDefaultAsync(
                    _readModel.UserApiKeys
                              .Where(m => m.UserId == request.UserId)
                              .Select(m => new {Value = m.Value}),
                    cancellationToken);

                if (apiKey == null)
                    return NotFound($"Api key with user id '{request.UserId}' not found.");

                return Success(apiKey.Value);
            }
        }
    }
}
