using ArtQuiz.Domain;

namespace ArtQuiz.Application.Services.Interface;

public interface IImageService
{
    Task<string> SaveQuizImage(string imageBase64String, string imageType, ApplicationTypeEnum applicationType, LanguageTypeEnum languageType);
    Task<string> SaveAvatar(string imageBase64String, string imageType);

    string GetQuizImagePath(string imageName, ApplicationTypeEnum applicationType);
    string GetAvatarPath(string imageName);
}