using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.SearchUsersByNameQuery
{
    public sealed partial class SearchUserByNameQuery
    {
        internal sealed class Handler : IQueryHandler<SearchUserByNameQuery,
            OneOf<Results.SuccessResult, Results.NotFoundResult>>
        {
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;
            private readonly IImageService _imageService;

            public Handler(IReadModel readModel, IReadModelQueryExecutor readModelExecutor, IImageService imageService)
            {
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
                _imageService = imageService;
            }

            public async Task<OneOf<Results.SuccessResult, Results.NotFoundResult>>
                Handle(SearchUserByNameQuery request, CancellationToken cancellationToken)
            {
                var users = await _readModelExecutor
                    .ToListAsync((from user in _readModel.User
                        join userImage in _readModel.UserImages
                            on user.Id equals userImage.UserId into userImagesGroup
                        from userImage in userImagesGroup.DefaultIfEmpty()
                        where user.UserName.Contains(request.UserName)
                        select new
                        {
                            user.Id,
                            user.UserName,
                            Image = userImage != null ? userImage.Image : null
                        }).Take(5), cancellationToken);

                if (users == null || !users.Any())
                    return NotFound();

                var response = users
                    .Select(i => new SearchUserByNameAppModel()
                    {
                        Id = i.Id,
                        UserName = i.UserName,
                        UserImage = _imageService.GetAvatarPath(i.Image)
                    })
                    .ToArray();

                return Success(response);
            }
        }
    }
}