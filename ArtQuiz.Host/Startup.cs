using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.Models;
using ArtQuiz.Host.ApiKey;
using ArtQuiz.Host.Bindings.Follower;
using ArtQuiz.Host.Bindings.Quiz;
using ArtQuiz.Host.Bindings.User;
using ArtQuiz.Host.Filtres;
using ArtQuiz.Infrastructure;
using Hangfire;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IO;
using Microsoft.OpenApi.Models;
using RestApi;
using UseCases;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ArtQuiz.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddErrorActionResultFactory();

            services.AddMvc();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArtQuiz", Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "API Key authorization",
                    In = ParameterLocation.Header,
                    Name = "Api-Key",
                    Type = SecuritySchemeType.ApiKey
                });
                var dir = new DirectoryInfo(PlatformServices.Default.Application.ApplicationBasePath);
                foreach (var fi in dir.EnumerateFiles("*.xml"))
                    c.IncludeXmlComments(fi.FullName, true);
            });

            MapClasses(services);

            services.AddContext(_configuration.GetConnectionString("postgres"));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            
            services
                .AddAuthentication()
                .AddApiKey();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            app.UseForwardedHeaders();
            app.UseRouting();
            
            app.UseRequestResponseLogging();
            app.UseApiExceptionHandler();
            app.ExceptionLogging();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsEnvironment("Local") || env.IsEnvironment("Preprod"))
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArtQuizBackend v1"));

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapSwagger("swagger/{documentName}/swagger.json");
                });

                app.UseHangfireDashboard("/hangfire", new DashboardOptions
                {
                    Authorization = new[] { new HangfireAuthorizationFilter() }
                });
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
                app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            }
        }

        private static void MapClasses(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<RandomQuizDataModel, RandomQuizAppModel>();
                cfg.CreateMap<RandomQuizAppModel, RandomQuizResponse>();

                cfg.CreateMap<QuizDataModel, QuizAppModel>();
                cfg.CreateMap<QuizAppModel, QuizResponse>();

                cfg.CreateMap<QuizTagDataModel, QuizTagAppModel>();
                cfg.CreateMap<QuizTagAppModel, QuizTagResponse>();

                cfg.CreateMap<UserDataModel, UserAppModel>();
                cfg.CreateMap<UserAppModel, UserResponse>();

                cfg.CreateMap<QuizRespectDataModel, QuizRespectAppModel>();
                cfg.CreateMap<QuizRespectAppModel, QuizRespectResponse>();
                
                cfg.CreateMap<CurrentUserRespectDataModel, CurrentUserRespectAppModel>();
                cfg.CreateMap<CurrentUserRespectAppModel, CurrentUserRespectResponse>();

                cfg.CreateMap<QuizByIdAppModel, AthQuizByIdResponse>();
                cfg.CreateMap<QuizByIdAppModel, QuizByIdResponse>();
                cfg.CreateMap<QuizByIndexAppModel, QuizByIndexResponse>();

                cfg.CreateMap<UserByIdDataModel, UserByIdAppModel>();
                cfg.CreateMap<UserByIdAppModel, UserByIdResponse>();
                cfg.CreateMap<UserByIdAppModel, AthUserByIdResponse>();

                cfg.CreateMap<SearchUserByNameAppModel, SearchUserByNameResponse>();

                cfg.CreateMap<SubscriptionAppModel, SubscriptionResponse>();
            }, typeof(AthQuizByIdResponse), typeof(QuizByIdAppModel));
        }
    }
}