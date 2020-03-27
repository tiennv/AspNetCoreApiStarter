using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class LogoutDtoRequest : IUseCaseRequest<LogoutDtoResponse>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string SigningKey { get; }
        public LogoutDtoRequest(string accessToken, string signingKey, string refreshToken)
        {
            AccessToken = accessToken;
            SigningKey = signingKey;
            RefreshToken = refreshToken;
        }
    }
}
