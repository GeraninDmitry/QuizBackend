using ArtQuiz.Application;
using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Infrastructure.ReadModels;
using ArtQuiz.Infrastructure.Repositories.AdLog;
using ArtQuiz.Infrastructure.Repositories.Quiz;
using ArtQuiz.Infrastructure.Repositories.QuizMark;
using ArtQuiz.Infrastructure.Repositories.QuizRespect;
using ArtQuiz.Infrastructure.Repositories.UserApiKeys;
using ArtQuiz.Infrastructure.Repositories.UserFollower;
using ArtQuiz.Infrastructure.Repositories.UserImage;
using ArtQuiz.Infrastructure.Services;
using ArtQuiz.Infrastructure.Services.EmailService;
using ArtQuiz.Infrastructure.Storage;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadModels.EntityFramework;
using UseCases;

namespace ArtQuiz.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IApplicationConfigurationBuilder AddContext(this IServiceCollection services, string dataBaseConnectionString)
        {
            services.AddUseCases(ApplicationDefinition.Assembly);
            services.AddAutoMapper(ApplicationDefinition.Assembly);

            services.AddSingleton<IDataStorage>(new DefaultDataStorage(dataBaseConnectionString));
            
            services.AddDbContextPool<UserApiKeysDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IUserApiKeysRepository, UserApiKeysRepository>();
            
            services.AddDbContextPool<QuizzesDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IQuizzesRepository, QuizzesRepository>();
            
            services.AddDbContextPool<QuizMarksDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IQuizMarksRepository, QuizMarksRepository>();
            
            services.AddDbContextPool<QuizRespectDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IQuizRespectRepository, QuizRespectRepository>();
            
            services.AddDbContextPool<UserFollowersDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IUserFollowersRepository, UserFollowersRepository>();
            
            services.AddDbContextPool<UserImagesDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IUserImagesRepository, UserImagesRepository>();
            
            services.AddDbContextPool<AdLogsDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IAdLogsRepository, AdLogsRepository>();
            
            services.AddDbContextPool<ReadModelDbContext>(options => options.UseNpgsql(dataBaseConnectionString));
            services.AddScoped<IReadModel, ReadModel>();
            services.AddEntityFrameworkReadModelExecutor();
            
            services.AddScoped<IBackgroundJobScheduler, HangfireBackgroundJobScheduler>();
            
            services.AddHangfire(gc =>
                gc.UseSerilogLogProvider().UsePostgreSqlStorage(dataBaseConnectionString, new PostgreSqlStorageOptions()
                {
                    
                }));
            services.AddHangfireServer();
            
            services
                .AddIdentityCore<IdentityUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Tokens.ProviderMap.Add("Default", new TokenProviderDescriptor(typeof(CustomTokenProvider<IdentityUser>)));
                })
                .AddTokenProvider<CustomTokenProvider<IdentityUser>>("Custom")
                .AddEntityFrameworkStores<ReadModelDbContext>();
            
            services.AddScoped<IUserTwoFactorTokenProvider<IdentityUser>, CustomTokenProvider<IdentityUser>>();
            
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IVerificationService, VerificationService>();
            services.AddScoped<ITemplateStringRender, TemplateStringRender>();
            
            services.AddScoped<IImageService, ImageService>();
            
            return new ApplicationConfigurationBuilder(services, dataBaseConnectionString);
        }
    }
}