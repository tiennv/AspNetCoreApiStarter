using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.UseCaseRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IRolePermissionRepository : IRepository<Role_Permission>
    {
        Task<int> Create(RolePermissionDtoRequest request);
    }
}
