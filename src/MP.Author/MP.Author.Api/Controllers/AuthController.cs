using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Api.Models;
using MP.Author.Api.ViewModels.Auth;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}

		// POST: /auth/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody]LoginViewModel vm)
		{
			// Validate the requests
			if (!ModelState.IsValid)
			{
				return BadRequest(); // TODO: Say what's wrong with the request
			}

			var result = await _signInManager.PasswordSignInAsync(
				userName: vm.Username,
				password: vm.Password,
				isPersistent: true, // TODO: Get this from the viewmodel
				lockoutOnFailure: true
			);

			if (result.RequiresTwoFactor)
			{
				return StatusCode(StatusCodes.Status501NotImplemented);
			}
			if (result.IsLockedOut)
			{
				return StatusCode(StatusCodes.Status423Locked);
			}
			if (result.Succeeded)
			{
				return Ok();
			}

			return Unauthorized();
		}

		[Authorize, HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Ok();
		}
	}
}