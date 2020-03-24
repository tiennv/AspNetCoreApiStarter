using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AIC.Author.Core.Domain.Entities;
using AIC.Author.Core.Dto;
using AIC.Author.Core.Dto.GatewayResponses.Repositories;
using AIC.Author.Core.Interfaces.Gateways.Repositories;
using AIC.Author.Core.Specifications;
using AIC.Author.Infrastructure.Identity;


namespace AIC.Author.Infrastructure.Data.Repositories
{
    internal sealed class UserRepository : EfRepository<User>, IUserRepository
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        

        public UserRepository(IMapper mapper, AppDbContext appDbContext): base(appDbContext)
        {
            //_userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password)
        {
            var appUser = new AppUser {Email = email, UserName = userName};
            //var identityResult = await _userManager.CreateAsync(appUser, password);

            //if (!identityResult.Succeeded) return new CreateUserResponse(appUser.Id, false,identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
          
            //var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            //_appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return null;
            //return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            //var appUser = await _userManager.FindByNameAsync(userName);
            //return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
            return null;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return false;
            //return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }
    }
}
