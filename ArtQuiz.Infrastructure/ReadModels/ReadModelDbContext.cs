using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework.Migrations;

namespace ArtQuiz.Infrastructure.ReadModels;

public sealed class ReadModelDbContext : IdentityUserDbContext
{
    public ReadModelDbContext(DbContextOptions<ReadModelDbContext> options) : base(options) =>
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    internal DbSet<UserApiKeyModel> UserApiKeys { get; set; }
    internal DbSet<MessageTemplateModel> MessageTemplates { get; set; }
    internal DbSet<QuizModel> Quizzes { get; set; }
    internal DbSet<QuizTagModel> QuizTags { get; set; }
    internal DbSet<QuizMarkModel> QuizMarks { get; set; }
    internal DbSet<QuizRespectModel> QuizRespects { get; set; }
    internal DbSet<UserFollowerModel> UserFollowers { get; set; }
    internal DbSet<UserImageModel> UserImages { get; set; }
    internal DbSet<AdModel> Ads { get; set; }
    internal DbSet<AdLogModel> AdLogs { get; set; }
    internal DbSet<AdSettingModel> AdSettings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserApiKeyModel>(builder =>
        {
            builder.ToTable("UserApiKey");
            builder.HasKey(p => p.UserApiKeyId);
        });
        
        modelBuilder.Entity<MessageTemplateModel>(builder =>
        {
            builder.ToTable("MessageTemplate");
            builder.HasKey(p => p.MessageTemplateId);
        });
        
        modelBuilder.Entity<QuizModel>(builder =>
        {
            builder.ToTable("Quiz");
            builder.HasKey(p => p.QuizId);
        });
        
        modelBuilder.Entity<QuizTagModel>(builder =>
        {
            builder.ToTable("QuizTag");
            builder.HasKey(p => p.QuizTagId);
        });
        
        modelBuilder.Entity<QuizMarkModel>(builder =>
        {
            builder.ToTable("QuizMark");
            builder.HasKey(p => p.QuizMarkId);
        });
        
        modelBuilder.Entity<QuizRespectModel>(builder =>
        {
            builder.ToTable("QuizRespect");
            builder.HasKey(p => p.QuizRespectId);
        });
        
        modelBuilder.Entity<UserFollowerModel>(builder =>
        {
            builder.ToTable("UserFollower");
            builder.HasKey(p => p.UserFollowerId);
        });
        
        modelBuilder.Entity<UserImageModel>(builder =>
        {
            builder.ToTable("UserImage");
            builder.HasKey(p => p.UserImageId);
        });
        
        modelBuilder.Entity<AdModel>(builder =>
        {
            builder.ToTable("Ad");
            builder.HasKey(p => p.AdId);
        });
        
        modelBuilder.Entity<AdLogModel>(builder =>
        {
            builder.ToTable("AdLog");
            builder.HasKey(p => p.AdLogId);
        });
        
        modelBuilder.Entity<AdSettingModel>(builder =>
        {
            builder.ToTable("AdSetting");
            builder.HasKey(p => p.AdSettingId);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}