using Microsoft.AspNetCore.Identity;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Infrastructure.Identity;
using System;
using System.Linq;
using MP.Author.Core.Dto;
using System.Threading.Tasks;
using AutoMapper;
using MP.Author.Core.Specifications;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class UserRepository : EfRepository<User>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IMapper _mapper;
        public UserRepository(UserManager<AppUser> userManager, IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }

        public async Task<bool> IsExistRefreshToken(string refreshToken)
        {
            var obj = _appDbContext.RefreshTokens.Any(x => x.Token.Equals(refreshToken));
            return obj;
        }

        public async Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password)
        {
            var appUser = new AppUser { Email = email, UserName = userName };
            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded) return new CreateUserResponse(appUser.Id, false, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));

            var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
        }

        public async Task<bool> RemoveRefreshToken(User user)
        {
            var refreshToken = _appDbContext.RefreshTokens.FirstOrDefault(x => x.UserId == user.Id);
            if (refreshToken != null)
            {
                _appDbContext.RefreshTokens.Remove(refreshToken);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
