using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IExchangeRefreshTokenUseCase : IUseCaseRequestHandler<ExchangeRefreshTokenDtoRequest, ExchangeRefreshTokenDtoResponse>
    {
        Task<bool> ValidationToken(ExchangeRefreshTokenDtoRequest message);
    }
}
