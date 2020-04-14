using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginDtoRequest, LoginDtoResponse>
    {
        Task<bool> ValidationPermissions(ValidationPermissionDtoRequest request, IOutputPort<ValidationPermissionDtoResponse> outputPort);
    }
}
