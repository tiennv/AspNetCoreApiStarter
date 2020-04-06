using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IObjectsUseCase : IUseCaseRequestHandler<ObjectsDtoRequest, ObjectsDtoResponse>
    {
        Task<bool> Get(int id, IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Gets(IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> GetParent(IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Update(ObjectsDtoRequest message, IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Create(List<ObjectsDtoRequest> request, IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Delete(List<ObjectsDtoRequest> ids, IOutputPort<ObjectsDtoResponse> outputPort);
    }
}
