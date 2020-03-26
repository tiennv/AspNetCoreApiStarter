using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class LogoutRequest : IUseCaseRequest<LogoutResponse>
    {
        public string AccessToken { get; }
        public string SigningKey { get; }
        public LogoutRequest(string accessToken, string signingKey)
        {
            AccessToken = accessToken;
            SigningKey = signingKey;
        }
    }
}
