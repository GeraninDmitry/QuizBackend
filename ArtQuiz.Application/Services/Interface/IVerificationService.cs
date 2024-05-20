using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;

namespace ArtQuiz.Application.Services.Interface;

public interface IVerificationService
{
    Task GenerateAndSendVerificationCode(string userName, LanguageTypeEnum language, ApplicationTypeEnum application);
}