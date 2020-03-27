using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.Services;
using MP.Author.Core.Interfaces.UseCases;
using MP.Author.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class ExchangeRefreshTokenUseCase : IExchangeRefreshTokenUseCase
    {
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;


        public ExchangeRefreshTokenUseCase(IJwtTokenValidator jwtTokenValidator, IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _jwtTokenValidator = jwtTokenValidator;
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        public async Task<bool> Handle(ExchangeRefreshTokenDtoRequest message, IOutputPort<ExchangeRefreshTokenResponse> outputPort)
        {
            var cp = _jwtTokenValidator.GetPrincipalFromToken(message.AccessToken, message.SigningKey);

            // invalid token/signing key was passed and we can't extract user claims
            if (cp != null)
            {
                var id = cp.Claims.First(c => c.Type == "id");
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(id.Value));

                if (user.HasValidRefreshToken(message.RefreshToken))
                {
                    var jwtToken = await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.UserName);
                    var refreshToken = _tokenFactory.GenerateToken();
                    user.RemoveRefreshToken(message.RefreshToken); // delete the token we've exchanged
                    user.AddRefreshToken(refreshToken, user.Id, ""); // add the new one
                    await _userRepository.Update(user);
                    outputPort.Handle(new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true));
                    return true;
                }
            }
            outputPort.Handle(new ExchangeRefreshTokenResponse(false, "Invalid token."));
            return false;
        }
    }
}
