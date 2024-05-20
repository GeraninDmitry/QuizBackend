using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace ArtQuiz.Application.Services;

public class CustomTokenProvider<TUser> : IUserTwoFactorTokenProvider<TUser> where TUser : IdentityUser
{
    private const string CacheKeyPref = "CustomTokenProvider";
    
    private readonly IMemoryCache _cache;
    
    public CustomTokenProvider(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
    {
        return Task.FromResult(true);
    }

    public Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
    {
        var code = new Random().Next(10000, 99999);

        var existingCode = _cache.Get($"{CacheKeyPref}.{user.UserName}");

        if (existingCode != null)
            _cache.Remove($"{CacheKeyPref}.{user.UserName}");

        _cache.Set($"{CacheKeyPref}.{user.UserName}", $"{code}", TimeSpan.FromMinutes(30));
        
        return Task.FromResult($"{code}");
    }

    public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
    {
        var existingCode = _cache.Get($"{CacheKeyPref}.{user.UserName}") as string;
        
        return Task.FromResult(token == existingCode);
    }
    
    public string GetVerificationCode(string userName)
    {
        return _cache.Get($"{CacheKeyPref}.{userName}") as string;
    }
}