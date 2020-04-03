using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IPermissionsUserCase : IUseCaseRequestHandler<PermissionsDtoRequest, PermissionsDtoResponse>
    {
        Task<bool> GetAll(IOutputPort<PermissionsDtoResponse> outputPort);
    }
}
