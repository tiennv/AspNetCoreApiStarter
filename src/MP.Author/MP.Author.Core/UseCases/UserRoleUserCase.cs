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

        public async Task<UserRoleDtoResponse> CreateAsync(AddUserRoleDtoRequest request)
        {
            var requestDto = new List<UserRoleDtoRequest>();
            var result = false;
            if (request!=null && request.RoleIds!=null && request.RoleIds.Count>0)
            {
                requestDto = request.RoleIds.Select(x => new UserRoleDtoRequest(request.UserId, x)).ToList();
                result = await _userRoleRepository.Create(requestDto);
            }

            return new UserRoleDtoResponse(result, result ? "Thêm mới thành công" : "Thêm mới không thành công");
             
        }

        public Task<bool> Handle(UserRoleDtoRequest message, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            throw new NotImplementedException();
        }

       
    }
}
