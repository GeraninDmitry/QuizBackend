using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain.Ad;
using ArtQuiz.Domain.AdLog;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.QuizMark;
using Microsoft.AspNetCore.Identity;
using OneOf;
using UseCases;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace ArtQuiz.Application.Commands.AddAdLogCommand;

public sealed partial class AddAdLogCommand
{
    internal sealed class Handler : ICommandHandler<AddAdLogCommand,
        OneOf<Results.SuccessResult>>
    {
        private readonly IAdLogsRepository _adLogsRepository;

        public Handler(IAdLogsRepository adLogsRepository)
        {
            _adLogsRepository = adLogsRepository;
        }

        public async Task<OneOf<Results.SuccessResult>>
            Handle(AddAdLogCommand request, CancellationToken cancellationToken)
        {
            var adLogId = Guid.NewGuid();
            var adLog = new AdLog(new AdLogId(adLogId), new AdId(request.AdId), request.UserId);
            await _adLogsRepository.Save(adLog);

            return Success(adLogId);
        }
    }
}