using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetSubscriptionsQuery
{
    public sealed partial class GetSubscriptionsQuery
    {
        internal sealed class Handler : IQueryHandler<GetSubscriptionsQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IMapper _mapper;
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;
            private readonly IImageService _imageService;

            public Handler(IDataStorage dataStorage, IMapper mapper, IReadModel readModel, IReadModelQueryExecutor readModelExecutor,
                IImageService imageService)
            {
                _dataStorage = dataStorage;
                _mapper = mapper;
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
                _imageService = imageService;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
            {
                //todo: переделать на пагинацию
                var subscriptions =
                    await _readModelExecutor.ToArrayAsync((from userFollower in _readModel.UserFollowers
                        join userImage in _readModel.UserImages
                            on userFollower.FollowedUserId equals userImage.UserId into joinedData
                        from userImage in joinedData.DefaultIfEmpty()
                        where userFollower.UserId == request.UserId && userFollower.IsFollowing
                        select new
                        {
                            userFollower.FollowedUserId,
                            Image = userImage != null ? userImage.Image : null,
                            UserName = userFollower.FollowedUser.UserName
                        }).Take(500), cancellationToken);

                var response = subscriptions
                    .Select(i => new SubscriptionAppModel()
                    {
                        UserId = i.FollowedUserId,
                        UserName = i.UserName,
                        UserImage = _imageService.GetAvatarPath(i.Image)
                    }).ToArray();

                return Success(response);
            }
        }
    }
}