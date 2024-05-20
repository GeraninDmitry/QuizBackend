using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Controllers;
using UseCases;

namespace ArtQuiz.Host.Controllers;

[Route("api/common")]
[Consumes("application/json")]
[Produces("application/json")]
public class CommonController : ApiController
{
    public CommonController(IErrorActionResultFactory errorActionResultFactory) : base(errorActionResultFactory)
    {
    }

    /// <summary>
    /// Возвращает версию приложения
    /// </summary>
    /// <returns></returns>
    [HttpGet("getVersion")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetVersion(
        [FromServices] IQueryExecutor queryExecutor,
        CancellationToken cancellationToken = default)
    {
        //todo: реализовать
        return Ok("1.0.0");
    }
    
}