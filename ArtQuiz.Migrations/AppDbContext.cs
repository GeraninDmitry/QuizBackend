using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework.Migrations;

namespace ArtQuiz.Migrations;

public sealed class AppDbContext : IdentityUserDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
            throw new ArgumentNullException(nameof(modelBuilder));

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}