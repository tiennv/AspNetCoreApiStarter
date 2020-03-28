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
        Task<UserRoleDtoResponse> Create(AddUserRoleDtoRequest requests);
    }
}
