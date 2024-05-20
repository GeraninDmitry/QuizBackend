using ArtQuiz.Domain.QuizRespect;
using ArtQuiz.Infrastructure.Repositories.QuizRespect.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;

namespace ArtQuiz.Infrastructure.Repositories.QuizRespect;

public sealed class QuizRespectDbContext : AggregateRootDbContext<Guid, QuizRespectId, Domain.QuizRespect.QuizRespect, QuizRespectConfiguration>
{
    public QuizRespectDbContext(DbContextOptions<QuizRespectDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new QuizRespectConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}