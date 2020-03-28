using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IUserRoleUserCase : IUseCaseRequestHandler<UserRoleDtoRequest, UserRoleDtoResponse>
    {
        Task<bool> CreateAsync(AddUserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort);     
    }
}
