
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class ExchangeRefreshTokenDtoResponse : UseCaseResponseMessage
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenDtoResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public ExchangeRefreshTokenDtoResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
