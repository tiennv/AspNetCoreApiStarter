using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IMenusUseCase : IUseCaseRequestHandler<MenusDtoRequest, MenusDtoResponse>
    {
        Task<bool> AddItem(MenusDtoRequest request, IOutputPort<MenusDtoResponse> outputPort);
        Task<bool> Add(MenusDtoRequest request, IOutputPort<MenusDtoResponse> outputPort);
        Task<bool> Update(MenusDtoRequest request, IOutputPort<MenusDtoResponse> outputPort);
        Task Gets(IOutputPort<MenusDtoResponse> outputPort);
        Task Get(int menuId, IOutputPort<MenusDtoResponse> outputPort);
    }
}
