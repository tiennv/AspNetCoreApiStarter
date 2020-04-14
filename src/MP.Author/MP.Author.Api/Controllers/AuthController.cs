using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MP.Author.Api.Middleware;
using MP.Author.Api.Models;
using MP.Author.Api.Models.Request;
using MP.Author.Api.Models.Settings;
using MP.Author.Api.Presenters;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
	
		private readonly ILoginUseCase _loginUseCase;
		private readonly ILogoutUseCase _logoutUseCase;
		private readonly LoginPresenter _loginPresenter;
		private readonly LogoutPresenter _logoutPresenter;
		private readonly IExchangeRefreshTokenUseCase _exchangeRefreshTokenUseCase;
		private readonly ExchangeRefreshTokenPresenter _exchangeRefreshTokenPresenter;
		private readonly ValidationPermissionPresenter _validationPermissionPresenter;

		private readonly AuthSettings _authSettings;

		public AuthController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter, ILogoutUseCase logoutUseCase,  LogoutPresenter logoutPresenter, 
			IExchangeRefreshTokenUseCase exchangeRefreshTokenUseCase, ExchangeRefreshTokenPresenter exchangeRefreshTokenPresenter, ValidationPermissionPresenter validationPermissionPresenter,
			IOptions<AuthSettings> authSettings)
		{
			_loginUseCase = loginUseCase;
			_logoutUseCase = logoutUseCase;
			_loginPresenter = loginPresenter;
			_logoutPresenter = logoutPresenter;
			_exchangeRefreshTokenUseCase = exchangeRefreshTokenUseCase;
			_exchangeRefreshTokenPresenter = exchangeRefreshTokenPresenter;
			_validationPermissionPresenter = validationPermissionPresenter;
			_authSettings = authSettings.Value;
		}


		// POST: /auth/login
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			await _loginUseCase.Handle(new LoginDtoRequest(request.UserName, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), _loginPresenter);
			return _loginPresenter.ContentResult;
		}

		// POST api/auth/refreshtoken
		[HttpPost("refreshtoken")]
		[ServiceFilter(typeof(SecurityFilter))]
		public async Task<ActionResult> RefreshToken([FromBody] ExchangeRefreshTokenRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			await _exchangeRefreshTokenUseCase.Handle(new ExchangeRefreshTokenDtoRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), _exchangeRefreshTokenPresenter);
			return _exchangeRefreshTokenPresenter.ContentResult;
		}

		[HttpPost("logout")]
		[ServiceFilter(typeof(SecurityFilter))]
		public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			await _logoutUseCase.Handle(new LogoutDtoRequest(request.AccessToken, _authSettings.SecretKey,request.RefreshToken), _logoutPresenter);
			return _logoutPresenter.ContentResult;
		}

		[HttpPost("validation-permissions")]
		[ServiceFilter(typeof(SecurityFilter))]
		public async Task<IActionResult> ValidationPermissionAsync([FromBody] ValidationPermissionRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			Microsoft.Extensions.Primitives.StringValues authToken;
			HttpContext.Request.Headers.TryGetValue("Authorization", out authToken);
			var _token = authToken.FirstOrDefault().Replace(JwtBearerDefaults.AuthenticationScheme.ToString(), "").Trim();
			var requestDto = new ValidationPermissionDtoRequest(request.Route, request.ControllerName, request.ActionName, _token, _authSettings.SecretKey);
			await _loginUseCase.ValidationPermissions(requestDto, _validationPermissionPresenter);
			return _validationPermissionPresenter.ContentResult;
			
		}

		[HttpGet("validation-token")]
		[ServiceFilter(typeof(SecurityFilter))]
		public IActionResult ValidationToken()
		{
			return Ok(new { 
				code = 200,
				msg = "Token valid!"
			});
		}
	}
}