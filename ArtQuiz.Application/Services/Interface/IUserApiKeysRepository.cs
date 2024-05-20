using ArtQuiz.Domain.UserApiKeys;
using Persistence;

namespace ArtQuiz.Application.Services.Interface;


public interface IUserApiKeysRepository : IAggregateRootRepository<Guid, UserApiKeyId, UserApiKey> { }