using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class UserRoleUserCase : IUserRoleUserCase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleUserCase(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
       

        public async Task<bool> CreateAsync(AddUserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            var response = await _userRoleRepository.Create(request);
            outputPort.Handle(response);
            return response.Success;
        }

        public Task<bool> Handle(UserRoleDtoRequest message, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            return null;
        }

       
    }
}
