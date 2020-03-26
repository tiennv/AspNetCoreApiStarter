using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.Services;
using MP.Author.Core.Interfaces.UseCases;
using MP.Author.Core.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class LogoutUseCase : ILogoutUseCase
    {
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IUserRepository _userRepository;        

        public LogoutUseCase(IJwtTokenValidator jwtTokenValidator, IUserRepository userRepository)
        {
            _jwtTokenValidator = jwtTokenValidator;
            _userRepository = userRepository;
            
        }


        public async Task<bool> Handle(LogoutRequest message, IOutputPort<LogoutResponse> outputPort)
        {
            var cp = _jwtTokenValidator.GetPrincipalFromToken(message.AccessToken, message.SigningKey);

            // invalid token/signing key was passed and we can't extract user claims
            if (cp != null)
            {
                var id = cp.Claims.First(c => c.Type == "id");
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(id.Value));

                if (user!=null)
                {
                    if(await _userRepository.RemoveRefreshToken(user))
                    {
                        outputPort.Handle(new LogoutResponse(true, "Logout success!"));
                        return true;
                    }
                    else
                    {
                        outputPort.Handle(new LogoutResponse(new[] { new Error("logout_failure", "Logout failure!")}));
                        return false;
                    }
                }
            }
            outputPort.Handle(new LogoutResponse(new[] { new Error("invalid_token", "Invalid token!") }));
            return false;
        }
    }
}
