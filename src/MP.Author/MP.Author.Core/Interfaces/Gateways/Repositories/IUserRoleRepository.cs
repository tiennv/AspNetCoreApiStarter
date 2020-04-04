using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRoleDtoResponse> Create(UserRoleDtoRequest requests);
        Task<UserRoleDtoResponse> Delete(UserRoleDtoRequest requests);
        Task<List<UserRoleDto>> GetRoleByUserId(string userId);


    }
}
