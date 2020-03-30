using MP.Author.Core.Dto.GatewayResponses.Repositories;
using System.Threading.Tasks;
using MP.Author.Core.Domain.Entities;
using System.Collections.Generic;
using MP.Author.Core.Dto;

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

        Task<bool> IsExistRefreshToken(string refreshToken);

        Task<List<RoleDto>> GetRoles(string username);

        Task<List<ObjectDto>> GetObjects(string username);
    }
}
