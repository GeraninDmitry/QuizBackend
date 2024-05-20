using ArtQuiz.Domain.UserFollower;
using ArtQuiz.Infrastructure.Repositories.UserFollower.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserFollower;

public sealed class UserFollowersDbContext : AggregateRootDbContext<Guid, UserFollowerId, Domain.UserFollower.UserFollower, UserFollowersConfiguration>
{
    public UserFollowersDbContext(DbContextOptions<UserFollowersDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new UserFollowersConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}