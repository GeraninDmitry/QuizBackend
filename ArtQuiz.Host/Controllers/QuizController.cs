using System.Net;
using System.Security.Claims;
using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.Commands.AddQuizCommand;
using ArtQuiz.Application.Commands.AddQuizMarkCommand;
using ArtQuiz.Application.Commands.AddQuizRespectCommand;
using ArtQuiz.Application.Dto;
using ArtQuiz.Application.Enums;
using ArtQuiz.Application.Queries.GetQuizAmountQuery;
using ArtQuiz.Application.Queries.GetQuizByIdQuery;
using ArtQuiz.Application.Queries.GetQuizByIndexQuery;
using ArtQuiz.Application.Queries.GetRandomQuizQuery;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using ArtQuiz.Host.Bindings.Quiz;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Controllers;
using RestApi.Middlewares;
using UseCases;

namespace ArtQuiz.Host.Controllers;

[Route("api/quiz")]
[Consumes("application/json")]
[Produces("application/json")]
public class QuizController : ApiController
{
    public QuizController(IErrorActionResultFactory errorActionResultFactory) : base(errorActionResultFactory)
    {
    }

    /// <summary>
    /// Создание квиза
    /// </summary>
    /// <param name="commandExecutor"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("addQuiz")]
    [Authorize]
    [DoNotLogRequestBody]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddQuiz(
        [FromServices] ICommandExecutor commandExecutor,
        AddQuizRequest request,
        CancellationToken cancellationToken = default)
        => (await commandExecutor.Execute(
                new AddQuizCommand(User.FindFirst(ClaimTypes.NameIdentifier).Value, request.Type, request.Theme, request.ApplicationType,
                    request.LanguageType, request.Title, request.Image, request.ImageType, request.Text,
                    request.Tags.Select(i => new QuizTagDto { Text = i.Text, IsTrue = i.IsTrue }).ToList()), cancellationToken))
            .Match(
                success => Ok(),
                conflict => Conflict(conflict.Message));

    /// <summary>
    /// Поставить отметку квизу
    /// </summary>
    /// <param name="commandExecutor"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("addQuizMark")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddQuizMark(
        [FromServices] ICommandExecutor commandExecutor,
        AddQuizMarkRequest request,
        CancellationToken cancellationToken = default)
        => (await commandExecutor.Execute(
                new AddQuizMarkCommand(User.FindFirst(ClaimTypes.NameIdentifier).Value, request.Type, request.QuizId, request.IsActive),
                cancellationToken))
            .Match(
                success => Ok());

    /// <summary>
    /// Поставить оценку квизу
    /// </summary>
    /// <param name="commandExecutor"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("addQuizRespect")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddQuizRespect(
        [FromServices] ICommandExecutor commandExecutor,
        AddQuizRespectRequest request,
        CancellationToken cancellationToken = default)
        => (await commandExecutor.Execute(
                new AddQuizRespectCommand(User.FindFirst(ClaimTypes.NameIdentifier).Value, request.QuizId, request.IsLiked, request.IsDisliked),
                cancellationToken))
            .Match(
                success => Ok());

    /// <summary>
    /// Получить случайный квиз
    /// </summary>
    /// <param name="queryExecutor"></param>
    /// <param name="searchType"></param>
    /// <param name="typeFlag"></param>
    /// <param name="themeFlag"></param>
    /// <param name="languageType"></param>
    /// <param name="isNewQuiz"></param>
    /// <param name="isSubscribed"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="applicationType"></param>
    /// <returns></returns>
    [HttpGet("getRandomQuiz")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RandomQuizResponse))]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetRandomQuiz(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        QuizSearchType searchType,
        QuizType.QuizTypeEnum typeFlag,
        QuizTheme.QuizThemeEnum themeFlag,
        ApplicationTypeEnum applicationType,
        LanguageTypeEnum languageType,
        bool isNewQuiz,
        bool isSubscribed,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetRandomQuizQuery(searchType, typeFlag, themeFlag, applicationType, languageType,
                    User.FindFirst(ClaimTypes.NameIdentifier)?.Value, isNewQuiz, isSubscribed),
                cancellationToken))
            .Match(
                success => Ok(mapper.Map<RandomQuizResponse>(success.Quiz)),
                notFound => NotFound(notFound.Message));

    /// <summary>
    /// Получить количество квизов (авторизованный пользователь)
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAthQuizAmountByUserId")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ulong))]
    public async Task<IActionResult> GetAthQuizAmountByUserId(
        [FromServices] IQueryExecutor queryExecutor,
        ApplicationTypeEnum applicationType,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizAmountQuery(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, true, applicationType),
                cancellationToken))
            .Match(
                success => Ok(success.Amount));

    /// <summary>
    /// Получить количество квизов
    /// </summary>
    /// <returns></returns>
    [HttpGet("getQuizAmountByUserId")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ulong))]
    public async Task<IActionResult> GetQuizAmountByUserId(
        [FromServices] IQueryExecutor queryExecutor,
        string userId,
        ApplicationTypeEnum applicationType,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizAmountQuery(userId, false, applicationType),
                cancellationToken))
            .Match(
                success => Ok(success.Amount));

    /// <summary>
    /// Получить квиз по id (авторизованный пользователь получает свой квиз)
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAthQuizById")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AthQuizByIdResponse))]
    public async Task<IActionResult> GetAthQuizById(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        Guid quizId,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizByIdQuery(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, quizId, true),
                cancellationToken))
            .Match(
                success => Ok(mapper.Map<AthQuizByIdResponse>(success.Quiz)));

    /// <summary>
    /// Получить квиз по id
    /// </summary>
    /// <returns></returns>
    [HttpGet("getQuizById")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AthQuizByIdResponse))]
    public async Task<IActionResult> GetQuizById(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        string userId,
        Guid quizId,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizByIdQuery(userId, quizId, false),
                cancellationToken))
            .Match(
                success => Ok(mapper.Map<QuizByIdResponse>(success.Quiz)));

    /// <summary>
    /// Получить квиз по index (авторизованный пользователь получает свой квиз)
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAthQuizByIndex")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(QuizByIndexResponse))]
    public async Task<IActionResult> GetAthQuizByIndex(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        uint quizIndex,
        ApplicationTypeEnum applicationType,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizByIndexQuery(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, quizIndex, true, applicationType),
                cancellationToken))
            .Match(
                success => Ok(mapper.Map<QuizByIndexResponse>(success.Quiz)));

    /// <summary>
    /// Получить квиз по index
    /// </summary>
    /// <returns></returns>
    [HttpGet("getQuizByIndex")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(QuizByIndexResponse))]
    public async Task<IActionResult> GetQuizByIndex(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        string userId,
        uint quizIndex,
        ApplicationTypeEnum applicationType,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetQuizByIndexQuery(userId, quizIndex, false, applicationType),
                cancellationToken))
            .Match(
                success => Ok(mapper.Map<QuizByIndexResponse>(success.Quiz)));
}