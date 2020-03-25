using MP.Author.Core.Dto;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}
