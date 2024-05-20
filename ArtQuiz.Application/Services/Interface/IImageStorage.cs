namespace ArtQuiz.Application.Services.Interface
{
    public interface IImageStorage
    {
        string GetGeneralUrl(string fileName);
        
        string GetAvatarUrl(string fileName);
    }
}