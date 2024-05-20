using ArtQuiz.Application.Services.Interface;
using ArtQuiz.Domain;
using Microsoft.AspNetCore.Hosting;

namespace ArtQuiz.Infrastructure.Services;

public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ImageService(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    private string GetRootPath() => _hostingEnvironment.WebRootPath;

    public async Task<string> SaveQuizImage(string imageBase64String, string imageType, ApplicationTypeEnum applicationType,
        LanguageTypeEnum languageType)
    {
        if (!IsImageTypeValid(imageType))
            throw new InvalidOperationException("Image type is not valid");

        var imageName = $"{Guid.NewGuid()}.{imageType}";

        var quizPath = GetQuizImagePath(applicationType, true);
        var filePath = Path.Combine(quizPath, imageName);

        await SaveBase64StringAsFile(imageBase64String, filePath);

        return imageName;
    }

    public string GetQuizImagePath(string imageName, ApplicationTypeEnum applicationType)
    {
        if (imageName == null)
            return null;
        
        var quizPath = GetQuizImagePath(applicationType, false);
        var filePath = Path.Combine(quizPath, imageName);

        return filePath;
    }

    private static bool IsImageTypeValid(string imageType)
    {
        return imageType == "png" || imageType == "jpg" || imageType == "jpeg" || imageType == "webp";
    }

    public async Task<string> SaveAvatar(string imageBase64String, string imageType)
    {
        if (!IsImageTypeValid(imageType))
            throw new InvalidOperationException("Image type is not valid");

        var imageName = $"{Guid.NewGuid()}.{imageType}";

        var avatarPath = GetAvatarPath(true);
        var filePath = Path.Combine(avatarPath, imageName);

        await SaveBase64StringAsFile(imageBase64String, filePath);

        return imageName;
    }

    public string GetAvatarPath(string imageName)
    {
        if (imageName == null)
            return null;
        
        var avatarPath = GetAvatarPath(false);
        var filePath = Path.Combine(avatarPath, imageName);

        return filePath;
    }

    private string GetQuizImagePath(ApplicationTypeEnum applicationType, bool withRoot)
    {
        var wwwRootPath = withRoot ? GetRootPath() : "";
        var filePath = Path.Combine(wwwRootPath, ((int)applicationType).ToString(), "quiz");
        return filePath;
    }


    private string GetAvatarPath(bool withRoot)
    {
        var wwwRootPath = withRoot ? GetRootPath() : "";
        var filePath = Path.Combine(wwwRootPath, "avatar");
        return filePath;
    }

    private async Task SaveBase64StringAsFile(string base64String, string filePath)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        var bytes = Convert.FromBase64String(base64String);

        if (bytes.Length > 1024 * 1024)
            throw new InvalidOperationException("Image size cannot be more than 1 MB");

        await File.WriteAllBytesAsync(filePath, bytes);
    }
}