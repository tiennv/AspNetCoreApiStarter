using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IRolePermissionUserCase : IUseCaseRequestHandler<RolePermissionDtoRequest, RolePermissionDtoResponse>
    {
        bool PostList(List<RolePermissionDtoRequest> requests, IOutputPort<RolePermissionDtoResponse> outputPort);
    }
}
