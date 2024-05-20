using ArtQuiz.Domain.Quiz;
using ArtQuiz.Domain.UserFollower;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserFollower.Configurations;


public sealed class UserFollowersConfiguration : AggregateRootTypeConfiguration<Guid, UserFollowerId, Domain.UserFollower.UserFollower> {
    public override void Configure(EntityTypeBuilder<Domain.UserFollower.UserFollower> builder) {
        
        builder.ToTable("UserFollower");
        
        
        base.Configure(builder);
    }
}