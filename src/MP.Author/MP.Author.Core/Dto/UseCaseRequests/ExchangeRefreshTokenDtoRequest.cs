using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class ExchangeRefreshTokenDtoRequest : IUseCaseRequest<ExchangeRefreshTokenResponse>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string SigningKey { get; }

        public ExchangeRefreshTokenDtoRequest(string accessToken, string refreshToken, string signingKey)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
        }
    }
}
