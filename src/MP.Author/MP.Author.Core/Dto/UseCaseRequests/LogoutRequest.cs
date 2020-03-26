using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class LogoutRequest : IUseCaseRequest<LogoutDtoResponse>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string SigningKey { get; }
        public LogoutRequest(string accessToken, string signingKey, string refreshToken)
        {
            AccessToken = accessToken;
            SigningKey = signingKey;
            RefreshToken = refreshToken;
        }
    }
}
