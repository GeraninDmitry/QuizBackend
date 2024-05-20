using ArtQuiz.Domain.Quiz;
using ArtQuiz.Infrastructure.Repositories.Quiz.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.Quiz;

public sealed class QuizzesDbContext : AggregateRootDbContext<Guid, QuizId, Domain.Quiz.Quiz, QuizzesConfiguration>
{
    public QuizzesDbContext(DbContextOptions<QuizzesDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new QuizzesConfiguration());
        modelBuilder.ApplyConfiguration(new QuizTagsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}