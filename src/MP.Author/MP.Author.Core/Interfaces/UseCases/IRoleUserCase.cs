using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IRoleUserCase : IUseCaseRequestHandler<RoleDtoRequest, RoleDtoResponse>
    {
    }
}
