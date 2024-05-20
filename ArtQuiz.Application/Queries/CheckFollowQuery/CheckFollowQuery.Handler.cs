using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.CheckFollowQuery
{
    public sealed partial class CheckFollowQuery
    {
        internal sealed class Handler : IQueryHandler<CheckFollowQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IMapper _mapper;
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;

            public Handler(IDataStorage dataStorage, IMapper mapper, IReadModel readModel, IReadModelQueryExecutor readModelExecutor)
            {
                _dataStorage = dataStorage;
                _mapper = mapper;
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(CheckFollowQuery request, CancellationToken cancellationToken)
            {
                var isFollowed = await _readModelExecutor.AnyAsync(_readModel.UserFollowers
                    .Where(i => i.UserId == request.UserId && i.FollowedUserId == request.FollowedUserId && i.IsFollowing), cancellationToken);

                return Success(isFollowed);
            }
        }
    }
}