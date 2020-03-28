using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IObjectsUserCase : IUseCaseRequestHandler<ObjectsDtoRequest, ObjectsDtoResponse>
    {
        Task<bool> Update(ObjectsDtoRequest message, IOutputPort<ObjectsDtoResponse> outputPort);
    }
}
