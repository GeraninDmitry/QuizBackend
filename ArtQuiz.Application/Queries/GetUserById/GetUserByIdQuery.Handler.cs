using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Quiz;
using AutoMapper;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetUserByIdQuery
{
    public sealed partial class GetUserByIdQuery
    {
        internal sealed class Handler : IQueryHandler<GetUserByIdQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IDataStorage _dataStorage;
            private readonly IMapper _mapper;
            private readonly IImageService _imageService;

            public Handler(IDataStorage dataStorage, IMapper mapper, IImageService imageService)
            {
                _dataStorage = dataStorage;
                _mapper = mapper;
                _imageService = imageService;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _dataStorage.GetUserById(request.UserId, cancellationToken);
                
                var response = _mapper.Map<UserByIdAppModel>(user);

                if (user.Image != null)
                {
                    var image = _imageService.GetAvatarPath(user.Image);
                    response.Image = image;
                }
                
                return Success(response);
            }
        }
    }
}