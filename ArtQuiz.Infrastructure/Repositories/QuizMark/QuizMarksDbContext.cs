using ArtQuiz.Domain.QuizMark;
using ArtQuiz.Infrastructure.Repositories.QuizMark.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizMark;

public sealed class QuizMarksDbContext : AggregateRootDbContext<Guid, QuizMarkId, Domain.QuizMark.QuizMark, QuizMarksConfiguration>
{
    public QuizMarksDbContext(DbContextOptions<QuizMarksDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new QuizMarksConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}