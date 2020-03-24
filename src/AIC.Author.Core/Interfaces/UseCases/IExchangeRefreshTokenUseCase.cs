using AIC.Author.Core.Dto.UseCaseRequests;
using AIC.Author.Core.Dto.UseCaseResponses;

namespace AIC.Author.Core.Interfaces.UseCases
{
    public interface IExchangeRefreshTokenUseCase : IUseCaseRequestHandler<ExchangeRefreshTokenRequest, ExchangeRefreshTokenResponse>
    {
    }
}
