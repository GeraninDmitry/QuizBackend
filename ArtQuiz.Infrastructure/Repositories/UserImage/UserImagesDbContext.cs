using ArtQuiz.Domain.UserImage;
using ArtQuiz.Infrastructure.Repositories.UserImage.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserImage;

public sealed class UserImagesDbContext : AggregateRootDbContext<Guid, UserImageId, Domain.UserImage.UserImage, UserImagesConfiguration>
{
    public UserImagesDbContext(DbContextOptions<UserImagesDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new UserImagesConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}