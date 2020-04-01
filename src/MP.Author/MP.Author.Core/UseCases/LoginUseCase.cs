
using AutoMapper;
using MP.Author.Core.Converts;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.Services;
using MP.Author.Core.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IOperationsRepository _operationsRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IObjectsRepository _objectsRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IMapper _mapper;

        public LoginUseCase(IUserRepository userRepository, IPermissionsRepository permissionsRepository, 
            IOperationsRepository operationsRepository, IObjectsRepository objectsRepository,
            IRolePermissionRepository rolePermissionRepository,
            IJwtFactory jwtFactory, ITokenFactory tokenFactory,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _permissionsRepository = permissionsRepository;
            _operationsRepository = operationsRepository;
            _objectsRepository = objectsRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
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
/*
        private List<ObjectDto> ReturnObjects(List<ObjectDto> source, List<ObjectDto> parentRoot)
        {
            var result = new List<ObjectDto>();
            
            foreach (var item in parentRoot)
            {
                RecusiveObjects(source, item, result);                
            }
            return result;
        }

        private List<ObjectDto> RecusiveObjects(List<ObjectDto> childs, ObjectDto parents, List<ObjectDto> target)
        {
            var objChild = childs.Where(x => x.ParentId.Equals(parents.Id));
            if (objChild != null && objChild.Count() > 0)
            {
                parents.Childrents = objChild.ToList();
                target.Add(parents);
                foreach (var child in objChild) {
                    return RecusiveObjects(childs, child, target);
                }
            }
            return target;
        }       */
    }
}
