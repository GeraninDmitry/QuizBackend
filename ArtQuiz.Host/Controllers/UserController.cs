using System.Net;
using System.Security.Claims;
using ArtQuiz.Application.Commands.AddUserAvatarCommand;
using ArtQuiz.Application.Commands.ChangePasswordCommand;
using ArtQuiz.Application.Commands.ConfirmUserCommand;
using ArtQuiz.Application.Commands.CreateUserApiKeyCommand;
using ArtQuiz.Application.Commands.CreateUserCommand;
using ArtQuiz.Application.Commands.SendVerificationCodeCommand;
using ArtQuiz.Application.Queries.CheckVerificationCodeQuery;
using ArtQuiz.Application.Queries.GetUserByIdQuery;
using ArtQuiz.Application.Queries.SearchUsersByNameQuery;
using ArtQuiz.Host.Bindings;
using ArtQuiz.Host.Bindings.Quiz;
using ArtQuiz.Host.Bindings.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using RestApi;
using RestApi.Controllers;
using RestApi.Middlewares;
using UseCases;

namespace ArtQuiz.Host.Controllers
{
    [Route("api/users")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UserController : ApiController
    {
        public UserController(IErrorActionResultFactory errorActionResultFactory) : base(errorActionResultFactory)
        {
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="commandExecutor"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("signUp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> SignUp(
            [FromServices] ICommandExecutor commandExecutor,
            SignUpRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(new CreateUserCommand(request.UserName, request.Password, request.Email,
                    request.Language, request.ApplicationTypeEnum), cancellationToken))
                .Match(
                    success => Ok(),
                    conflict => Conflict(conflict.Message));

        /// <summary>
        /// Подтверждение пользователя
        /// </summary>
        /// <param name="commandExecutor"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("confirm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> Confirm(
            [FromServices] ICommandExecutor commandExecutor,
            ConfirmRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(new ConfirmUserCommand(request.UserName, request.VerificationCode), cancellationToken))
                .Match(
                    success => Ok(),
                    conflict => Conflict(conflict.Message),
                    notFound => NotFound(notFound.Message));

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="commandExecutor"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> api key</returns>
        [HttpPost("logIn")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> LogIn(
            [FromServices] ICommandExecutor commandExecutor,
            LogInRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(new CreateUserApiKeyCommand(request.UserName, request.Password), cancellationToken))
                .Match(
                    success => Ok(success.Value),
                    conflict => Conflict(conflict.Message),
                    notFound => NotFound(notFound.Message));

        /// <summary>
        /// Отправить код верефикации
        /// </summary>
        /// <param name="commandExecutor"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("sendVerificationCode")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> SendVerificationCode(
            [FromServices] ICommandExecutor commandExecutor,
            SendVerificationCodeRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(new SendVerificationCodeCommand(request.UserName, request.Language,
                    request.ApplicationTypeEnum), cancellationToken))
                .Match(
                    success => Ok(),
                    notFound => NotFound(notFound.Message));

        /// <summary>
        /// Сменить пароль
        /// </summary>
        /// <param name="commandExecutor"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("changePassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> ChangePassword(
            [FromServices] ICommandExecutor commandExecutor,
            ChangePasswordRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(new ChangePasswordCommand(request.UserName, request.VerificationCode,
                    request.NewPassword), cancellationToken))
                .Match(
                    success => Ok(),
                    conflict => Conflict(conflict.Message),
                    notFound => NotFound(notFound.Message));

        /// <summary>
        /// Проверить код верефикации
        /// </summary>
        /// <param name="queryExecutor"></param>
        /// <param name="verificationCode"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("checkVerificationCode")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> CheckVerificationCode(
            [FromServices] IQueryExecutor queryExecutor,
            string userName,
            string verificationCode,
            CancellationToken cancellationToken = default)
            => (await queryExecutor.Execute(new CheckVerificationCodeQuery(userName, verificationCode), cancellationToken))
                .Match(
                    success => Ok(),
                    notFound => NotFound(notFound.Message),
                    conflict => Conflict(conflict.Message));

        /// <summary>
        /// Загрузить аватар пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("loadUserImage")]
        [Authorize]
        [DoNotLogRequestBody]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoadUserImage(
            [FromServices] ICommandExecutor commandExecutor,
            AddUserAvatarRequest request,
            CancellationToken cancellationToken = default)
            => (await commandExecutor.Execute(
                    new AddUserAvatarCommand(User.FindFirst(ClaimTypes.NameIdentifier).Value, request.Image, request.ImageType),
                    cancellationToken))
                .Match(
                    success => Ok());

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUserById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserByIdResponse))]
        public async Task<IActionResult> GetUserById(
            [FromServices] IQueryExecutor queryExecutor,
            [FromServices] IMapper mapper,
            string userId,
            CancellationToken cancellationToken = default)
            => (await queryExecutor.Execute(
                    new GetUserByIdQuery(userId, false),
                    cancellationToken))
                .Match(
                    success => Ok(mapper.Map<UserByIdResponse>(success.User)));

        /// <summary>
        /// Получить пользователя по id (авторизованный пользователь)
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAthUserById")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AthUserByIdResponse))]
        public async Task<IActionResult> GetAthUserById(
            [FromServices] IQueryExecutor queryExecutor,
            [FromServices] IMapper mapper,
            CancellationToken cancellationToken = default)
            => (await queryExecutor.Execute(
                    new GetUserByIdQuery(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, false),
                    cancellationToken))
                .Match(
                    success => Ok(mapper.Map<AthUserByIdResponse>(success.User)));

        /// <summary>
        /// Поиск пользователя по имени
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchUserByName")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SearchUserByNameResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SearchUserByName(
            [FromServices] IQueryExecutor queryExecutor,
            [FromServices] IMapper mapper,
            string userName,
            CancellationToken cancellationToken = default)
            => (await queryExecutor.Execute(
                    new SearchUserByNameQuery(userName),
                    cancellationToken))
                .Match<IActionResult>(
                    success => Ok(success.Users.Select(i => mapper.Map<SearchUserByNameResponse>(i))),
                    notFound => NotFound());
    }
}