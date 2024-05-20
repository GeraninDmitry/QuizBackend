using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtQuiz.Migrations.Entries;

public class MessageTemplateModel
{
    public Guid MessageTemplateId { get; set; }
    public int MessageType { get; set; }
    public int LanguageType { get; set; }
    public int EmailType { get; set; }
    public int ApplicationType { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime CreatedOn { get; set; }
    public long Version { get; private set; }
}

public sealed class MessageTemplateModelConfiguration : IEntityTypeConfiguration<MessageTemplateModel>
{
    public void Configure(EntityTypeBuilder<MessageTemplateModel> builder)
    {
        builder.ToTable("MessageTemplate");
        builder.HasKey(p => p.MessageTemplateId);
        
        builder.Property(p => p.MessageType).IsRequired();
        builder.Property(p => p.LanguageType).IsRequired();
        builder.Property(p => p.EmailType).IsRequired();
        builder.Property(p => p.ApplicationType).IsRequired();
        builder.Property(p => p.Subject).IsRequired();
        builder.Property(p => p.Body).IsRequired();
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.Version).IsRequired();
    }
}