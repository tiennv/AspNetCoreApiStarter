﻿using System.Threading.Tasks;
using AIC.Author.Core.Dto;
using AIC.Author.Core.Dto.UseCaseRequests;
using AIC.Author.Core.Dto.UseCaseResponses;
using AIC.Author.Core.Interfaces;
using AIC.Author.Core.Interfaces.Gateways.Repositories;
using AIC.Author.Core.Interfaces.Services;
using AIC.Author.Core.Interfaces.UseCases;


namespace AIC.Author.Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                // ensure we have a user with the given user name
                var user = await _userRepository.FindByName(message.UserName);
                if (user != null)
                {
                    // validate password
                    if (await _userRepository.CheckPassword(user, message.Password))
                    {
                        // generate refresh token
                        var refreshToken = _tokenFactory.GenerateToken();
                        user.AddRefreshToken(refreshToken, user.Id, message.RemoteIpAddress);
                        await _userRepository.Update(user);

                        // generate access token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.UserName), refreshToken, true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
