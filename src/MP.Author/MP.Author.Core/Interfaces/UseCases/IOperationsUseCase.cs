using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IOperationsUseCase : IUseCaseRequestHandler<OperationsDtoRequest, OperationsDtoResponse>
    {
        Task<bool> Delete(List<OperationsDtoRequest> ids, IOutputPort<OperationsDtoResponse> outputPort);

        Task<bool> Get(int id, IOutputPort<OperationsDtoResponse> outputPort);

        Task<bool> GetByObject(int objectId, IOutputPort<OperationsDtoResponse> outputPort);

        Task<bool> Gets(IOutputPort<OperationsDtoResponse> outputPort);
    }
}
