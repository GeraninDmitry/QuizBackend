using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtQuiz.Infrastructure.ReadModels;

public sealed class ReadModel : IReadModel
{
    private readonly ReadModelDbContext _context;

    public ReadModel(ReadModelDbContext context) => _context = context;

    public IQueryable<UserApiKeyModel> UserApiKeys => _context.UserApiKeys
        .Include(i => i.User);

    public IQueryable<MessageTemplateModel> MessageTemplates => _context.MessageTemplates;

    public IQueryable<QuizModel> Quizzes => _context.Quizzes
        .Include(i => i.User)
        .Include(i => i.Tags);

    public IQueryable<QuizTagModel> QuizTags => _context.QuizTags
        .Include(i => i.Quiz);

    public IQueryable<QuizMarkModel> QuizMarks => _context.QuizMarks
        .Include(i => i.User)
        .Include(i => i.Quiz);

    public IQueryable<QuizRespectModel> QuizRespects => _context.QuizRespects
        .Include(i => i.User)
        .Include(i => i.Quiz);

    public IQueryable<UserFollowerModel> UserFollowers => _context.UserFollowers
        .Include(i => i.User)
        .Include(i => i.FollowedUser);

    public IQueryable<UserImageModel> UserImages => _context.UserImages
        .Include(i => i.User);

    public IQueryable<IdentityUser> User => _context.Users;
    public IQueryable<AdModel> Ads => _context.Ads;
    public IQueryable<AdLogModel> AdLogs => _context.AdLogs
        .Include(i => i.User)
        .Include(i => i.Ad);
    public IQueryable<AdSettingModel> AdSettings => _context.AdSettings;
}