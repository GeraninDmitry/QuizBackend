using ArtQuiz.Domain.AdLog;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IAdLogsRepository: IAggregateRootRepository<Guid, AdLogId, AdLog> { }