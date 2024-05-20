using ArtQuiz.Domain.UserImage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.UserImage.Configurations;


public sealed class UserImagesConfiguration : AggregateRootTypeConfiguration<Guid, UserImageId, Domain.UserImage.UserImage> {
    public override void Configure(EntityTypeBuilder<Domain.UserImage.UserImage> builder) {
        
        builder.ToTable("UserImage");
        
        
        base.Configure(builder);
    }
}