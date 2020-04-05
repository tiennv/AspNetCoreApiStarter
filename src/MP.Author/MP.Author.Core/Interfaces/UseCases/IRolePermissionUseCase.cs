using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IRolePermissionUseCase : IUseCaseRequestHandler<RolePermissionDtoRequest, RolePermissionDtoResponse>
    {
        Task<bool> Create(List<RolePermissionDtoRequest> requests, IOutputPort<RolePermissionDtoResponse> outputPort);
        Task<bool> SetRoleObjectPermission(RolePermissionDtoRequest requests);
    }
}
