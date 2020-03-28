using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleResponse> Create(string name);
        Task<RoleResponse> Delete(string id);
        Task<RoleResponse> Update(string id, string name);
        Task<RoleResponse> GetRole(string id);
        //Task<List<RoleResponse>> GetRoles(User user);
    }
}
