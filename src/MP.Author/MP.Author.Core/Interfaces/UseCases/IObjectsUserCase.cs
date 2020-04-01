using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IObjectsUserCase : IUseCaseRequestHandler<ObjectsDtoRequest, ObjectsDtoResponse>
    {
        Task<bool> Update(ObjectsDtoRequest message, IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Create(List<ObjectsDtoRequest> request, IOutputPort<ObjectsDtoResponse> outputPort);
        Task<bool> Delete(List<ObjectsDtoRequest> ids, IOutputPort<ObjectsDtoResponse> outputPort);
    }
}
