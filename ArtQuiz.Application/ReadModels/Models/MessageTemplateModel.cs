using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;

namespace ArtQuiz.Application.ReadModels.Models;

public class MessageTemplateModel
{
    public Guid MessageTemplateId { get; private set; }
    public MessageType MessageType { get; private set; }
    public LanguageTypeEnum LanguageType { get; private set; }
    public EmailType EmailType { get; private set; }
    public ApplicationTypeEnum ApplicationType { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTime CreatedOn { get; private set; }
}