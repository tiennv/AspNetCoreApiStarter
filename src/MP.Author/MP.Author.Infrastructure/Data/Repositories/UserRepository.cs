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
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class UserRepository : EfRepository<User>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        //public UserRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, AppDbContext appDbContext, AppIdentityDbContext appIdentityDbContext) : base(appDbContext, appIdentityDbContext)
        //{
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _roleManager = roleManager;
        //}
        public UserRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, 
            AppDbContext appDbContext) : base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
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

        public async Task<List<RoleDto>> GetRoles(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            IList<string> roleNames = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.Where(x => roleNames.Any(r=>r.Equals(x.Name)));
            var roleDtos = _mapper.Map<List<RoleDto>>(roles.ToList());

            var roleIds = _roleManager.Roles.Where(x => roleNames.Any(r => r.Equals(x.Name))).Select(x=> x.Id);
            
            return roleDtos;
        }

        private async Task<List<string>> GetRoleIds(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            IList<string> roleNames = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.Where(x => roleNames.Any(r => r.Equals(x.Name)));
            var roleDtos = _mapper.Map<List<RoleDto>>(roles.ToList());

            var roleIds = _roleManager.Roles.Where(x => roleNames.Any(r => r.Equals(x.Name))).Select(x => x.Id);

            return roleIds.Distinct().ToList();
        }

        public async Task<List<ObjectDto>> GetObjects(string username)
        {
            var roleIds = await GetRoleIds(username);            

            var permissionIds = _appDbContext.Role_Permission.Where(x => roleIds.Any(r => r.Equals(x.RoleId))).Select(x => x.PermissionId).Distinct();

            var permissions = _appDbContext.Permissions.Where(x => permissionIds.Any(r => r.Equals(x.Id))).Distinct();

            var objectIds = permissions.Select(x => x.ObjectId).Distinct();

            var operationIds = permissions.Select(x => x.OperationId).Distinct();

            var objects = _appDbContext.Objects.Where(x => objectIds.Any(o => o.Equals(x.Id))).Distinct();

            var operations = _appDbContext.Operations.Where(x => operationIds.Any(o => o.Equals(x.Id))).Distinct();


            var objObjects = new List<ObjectDto>();

            foreach (var per in permissions.ToList())
            {
                var tempObj = objects.ToList().FirstOrDefault(x => x.Id.Equals(per.ObjectId));
                var tempOper = operations.ToList().FirstOrDefault(x => x.Id.Equals(per.OperationId));
                if (tempObj != null)
                {
                    var objDto = _mapper.Map<ObjectDto>(tempObj);
                    objDto.Operation = tempOper;
                    objObjects.Add(objDto);
                }
            }

            return objObjects;
        }        

    }
}
