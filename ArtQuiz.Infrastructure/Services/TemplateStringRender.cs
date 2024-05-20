using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using Scriban.Runtime;

namespace ArtQuiz.Infrastructure.Services;

public class TemplateStringRender : ITemplateStringRender
{
    public async ValueTask<string> RenderAsync(string body, IEnumerable<(string key, string value)> parameters)
    {
        var template = Scriban.Template.Parse(body);

        var model = new ScriptObject();
        foreach (var parameter in parameters)
            model.Add(parameter.key, parameter.value);

        return await template.RenderAsync(model);
    }
}