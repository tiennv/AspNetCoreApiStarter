using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IOperationsUserCase : IUseCaseRequestHandler<OperationsDtoRequest, OperationsDtoResponse>
    {
        Task<bool> Delete(List<OperationsDtoRequest> ids, IOutputPort<OperationsDtoResponse> outputPort);
    }
}
