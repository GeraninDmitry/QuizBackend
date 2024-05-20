namespace ArtQuiz.Application.Services.Interface;

public interface ITemplateStringRender
{
    ValueTask<string> RenderAsync(string body, IEnumerable<(string key, string value)> parameters);
}