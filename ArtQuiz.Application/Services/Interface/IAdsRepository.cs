using ArtQuiz.Domain.Ad;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;

public interface IAdsRepository: IAggregateRootRepository<Guid, AdId, Ad> { }