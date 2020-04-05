using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IUserRoleUseCase : IUseCaseRequestHandler<UserRoleDtoRequest, UserRoleDtoResponse>
    {
        Task<bool> Create(UserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort);
        Task<bool> Delete(UserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort);
        Task<bool> GetAllUser(IOutputPort<UserRoleDtoResponse> outputPort);
    }
}
