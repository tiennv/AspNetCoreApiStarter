using System.Threading.Tasks;
using AIC.Author.Core.Dto;

namespace AIC.Author.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}
