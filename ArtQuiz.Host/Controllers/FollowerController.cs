using System.Net;
using System.Security.Claims;
using ArtQuiz.Application.Commands.AddUserFollowerCommand;
using ArtQuiz.Application.Dto;
using ArtQuiz.Application.Queries.CheckFollowQuery;
using ArtQuiz.Application.Queries.GetSubscriptionsQuery;
using ArtQuiz.Host.Bindings.Follower;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi;
using RestApi.Controllers;
using UseCases;

namespace ArtQuiz.Host.Controllers;

[Route("api/follower")]
[Consumes("application/json")]
[Produces("application/json")]
public class FollowerController : ApiController
{
    public FollowerController(IErrorActionResultFactory errorActionResultFactory) : base(errorActionResultFactory)
    {
    }

    /// <summary>
    /// Cледовать за пользователем
    /// </summary>
    /// <param name="commandExecutor"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("followUser")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> FollowUser(
        [FromServices] ICommandExecutor commandExecutor,
        AddFollowUserRequest request,
        CancellationToken cancellationToken = default)
        => (await commandExecutor.Execute(
                new AddUserFollowerCommand(User.FindFirst(ClaimTypes.NameIdentifier).Value, request.FollowedUserId, request.IsFollowing),
                cancellationToken))
            .Match(
                success => Ok());
    
    /// <summary>
    /// Проверить подписку на пользователя
    /// </summary>
    /// <returns></returns>
    [HttpGet("checkFollow")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    public async Task<IActionResult> CheckFollow(
        [FromServices] IQueryExecutor queryExecutor,
        string followedUserId,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new CheckFollowQuery(User.FindFirst(ClaimTypes.NameIdentifier).Value, followedUserId),
                cancellationToken))
            .Match(
                success => Ok(success.IsFollowed));
    
    /// <summary>
    /// Получить подписки пользователя
    /// </summary>
    /// <returns></returns>
    [HttpGet("getSubscriptions")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubscriptionResponse[]))]
    public async Task<IActionResult> GetSubscriptions(
        [FromServices] IQueryExecutor queryExecutor,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
        => (await queryExecutor.Execute(
                new GetSubscriptionsQuery(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                cancellationToken))
            .Match(
                success => Ok(success.Subscriptions.Select(i => mapper.Map<SubscriptionResponse>(i))));
}