using ArtQuiz.Application.Enums;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using ReadModels;

namespace ArtQuiz.Application.Services;

public class VerificationService : IVerificationService
{
    private readonly IMemoryCache _cache;
    private readonly IBackgroundJobScheduler _backgroundJobScheduler;
    private readonly IReadModel _readModel;
    private readonly IReadModelQueryExecutor _readModelExecutor;
    private readonly ITemplateStringRender _templateStringRender;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMemoryCache _memoryCache;
    
    public VerificationService(IMemoryCache cache, IBackgroundJobScheduler backgroundJobScheduler,
        IReadModelQueryExecutor readModelExecutor, IReadModel readModel, ITemplateStringRender templateStringRender, UserManager<IdentityUser> userManager, IMemoryCache memoryCache)
    {
        _cache = cache;
        _backgroundJobScheduler = backgroundJobScheduler;
        _readModelExecutor = readModelExecutor;
        _readModel = readModel;
        _templateStringRender = templateStringRender;
        _userManager = userManager;
        _memoryCache = memoryCache;
    }

    public async Task GenerateAndSendVerificationCode(string userName, LanguageTypeEnum language, ApplicationTypeEnum application)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var code = await _userManager.GenerateUserTokenAsync(user, "Custom", "verification_code");

        var cacheKey = $"{nameof(VerificationService)}.{nameof(GenerateAndSendVerificationCode)}.{language}.{application}";
                
        if (!_memoryCache.TryGetValue(cacheKey, out (string body, string subject) message))
        {
            var response = await _readModelExecutor.FirstOrDefaultAsync(
                _readModel.MessageTemplates
                    .Where(m => m.EmailType == EmailType.VerificationCode)
                    .Where(m => m.LanguageType == language)
                    .Where(m => m.ApplicationType == application)
                    .Where(m => m.MessageType == MessageType.Email)
                    .Select(m => new {Body = m.Body, Subject = m.Subject}));

            message = (response.Body, response.Subject);
            _memoryCache.Set(cacheKey, (response.Body, response.Subject), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
        }
        
        var renderedBody = await _templateStringRender.RenderAsync(message.body, new[] {("code", code), ("userName", userName)});
        
        _backgroundJobScheduler.Enqueue<IEmailService>(emailService =>
            emailService.SendEmailAsync(user.Email, message.subject, renderedBody));
    }
    
}