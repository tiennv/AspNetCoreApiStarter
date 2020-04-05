using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IRoleUseCase : IUseCaseRequestHandler<RoleDtoRequest, RoleDtoResponse>
    {
        bool Gets(IOutputPort<RoleDtoResponse> outputPort);
        Task<bool> GetByUserAsync(string userid, IOutputPort<RoleDtoResponse> outputPort);
    }
}
