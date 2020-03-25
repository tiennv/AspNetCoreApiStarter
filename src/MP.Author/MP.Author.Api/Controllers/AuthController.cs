using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MP.Author.Api.Models;
using MP.Author.Api.Models.Settings;
using MP.Author.Api.Presenters;
using MP.Author.Api.ViewModels.Auth;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
	
		private readonly ILoginUseCase _loginUseCase;
		private readonly LoginPresenter _loginPresenter;
		private readonly IExchangeRefreshTokenUseCase _exchangeRefreshTokenUseCase;
		private readonly ExchangeRefreshTokenPresenter _exchangeRefreshTokenPresenter;
		private readonly AuthSettings _authSettings;

		public AuthController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter, IExchangeRefreshTokenUseCase exchangeRefreshTokenUseCase, ExchangeRefreshTokenPresenter exchangeRefreshTokenPresenter, IOptions<AuthSettings> authSettings)
		{
			_loginUseCase = loginUseCase;
			_loginPresenter = loginPresenter;
			_exchangeRefreshTokenUseCase = exchangeRefreshTokenUseCase;
			_exchangeRefreshTokenPresenter = exchangeRefreshTokenPresenter;
			_authSettings = authSettings.Value;
		}


		// POST: /auth/login
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), _loginPresenter);
			return _loginPresenter.ContentResult;
		}

		// POST api/auth/refreshtoken
		[HttpPost("refreshtoken")]
		public async Task<ActionResult> RefreshToken([FromBody] Models.Request.ExchangeRefreshTokenRequest request)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			await _exchangeRefreshTokenUseCase.Handle(new ExchangeRefreshTokenRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), _exchangeRefreshTokenPresenter);
			return _exchangeRefreshTokenPresenter.ContentResult;
		}

		[Authorize, HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			//await _signInManager.SignOutAsync();
			return Ok();
		}
	}
}