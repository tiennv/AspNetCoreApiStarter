using MP.Author.Core.Dto.GatewayResponses.Repositories;
using System.Threading.Tasks;
using MP.Author.Core.Domain.Entities;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);

        /// <summary>
        /// Remove Refresh Token table for logout case
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> RemoveRefreshToken(User user);
    }
}
