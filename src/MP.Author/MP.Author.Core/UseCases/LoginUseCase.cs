
using AutoMapper;
using MP.Author.Core.Converts;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.Services;
using MP.Author.Core.Interfaces.UseCases;
using MP.Author.Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;        
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IJwtTokenValidator _jwtTokenValidator;

        public LoginUseCase(IUserRepository userRepository,IJwtFactory jwtFactory, ITokenFactory tokenFactory, IJwtTokenValidator jwtTokenValidator)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _jwtTokenValidator = jwtTokenValidator;
        }

        public async Task<bool> Handle(LoginDtoRequest message, IOutputPort<LoginDtoResponse> outputPort)
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
                        var jwtToken = await _jwtFactory.GenerateEncodedToken(user);
                        await _userRepository.RemoveRefreshToken(user);
                        user.AddRefreshToken(refreshToken, jwtToken.Token, user.Id, message.RemoteIpAddress);
                        await _userRepository.Update(user);
                        var objs = await _userRepository.GetObjects(message.UserName);                        
                        var objParents = objs.Where(x => x.ParentId.Equals(0));                        
                        var target = ObjectsRecusiver.ReturnObjects(objs, objParents.ToList());
                        var roles = await _userRepository.GetRoles(message.UserName);                        
                        // generate access token
                        //outputPort.Handle(new LoginDtoResponse(target, roles, await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.UserName), refreshToken, true));
                        outputPort.Handle(new LoginDtoResponse(target, roles, jwtToken, refreshToken, true));
                        
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginDtoResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }

        public async Task<bool> ValidationPermissions(ValidationPermissionDtoRequest request, IOutputPort<ValidationPermissionDtoResponse> outputPort)
        {
            var cp = _jwtTokenValidator.GetPrincipalFromToken(request.AccessToken, request.SigningKey);
            if (cp != null)
            {
                var id = cp.Claims.First(c => c.Type == "id");
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(id.Value));
                if (user != null)
                {
                    var objs = await _userRepository.GetObjects(user.UserName);
                    var obj = objs.FirstOrDefault(x => (x.ControllerName.ToLower().Equals(request.ControllerName.ToLower()) && x.ActionName.ToLower().Equals(request.ActionName.ToLower()))
                                            || x.Route.ToLower().Equals(request.Route.ToLower()));

                    outputPort.Handle(new ValidationPermissionDtoResponse(obj, obj!=null, obj!=null ? "" : "Has not permission!"));
                    return true;
                }
                else
                {
                    outputPort.Handle(new ValidationPermissionDtoResponse(new Error("404", "User is null!"), null, false, "User is null!"));
                    return false;
                }
            }
            else
            {
                outputPort.Handle(new ValidationPermissionDtoResponse(new Error("401", "Invalid token!"), null, false, "Invalid token!"));
                return false;
            }
            
        }
    }
}
