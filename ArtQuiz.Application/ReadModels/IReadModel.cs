using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.ReadModels;

public interface IReadModel
{
    IQueryable<UserApiKeyModel> UserApiKeys { get; }
    IQueryable<MessageTemplateModel> MessageTemplates { get; }
    IQueryable<QuizModel> Quizzes { get; }
    IQueryable<QuizTagModel> QuizTags { get; }
    IQueryable<QuizMarkModel> QuizMarks { get; }
    IQueryable<QuizRespectModel> QuizRespects { get; }
    IQueryable<UserFollowerModel> UserFollowers { get; }
    IQueryable<UserImageModel> UserImages { get; }
    IQueryable<IdentityUser> User { get; }
    IQueryable<AdModel> Ads { get; }
    IQueryable<AdLogModel> AdLogs { get; }
    IQueryable<AdSettingModel> AdSettings { get; }
}