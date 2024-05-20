using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.EntityFramework.Migrations.Migrations;

namespace ArtQuiz.Migrations;

public sealed class AppMigrationService : IdentityUserMigrationService<AppDbContext>
{
    public AppMigrationService(IHostApplicationLifetime hostApplicationLifetime, AppDbContext context,
        ILogger<IdentityUserMigrationService<AppDbContext>> logger) : base(hostApplicationLifetime, context, logger) { }
}