using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Infrastructure.Helpers;
using MP.Author.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserManager<AppUser> _userManager;        
        private readonly IMapper _mapper;
        public UserRoleRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            //_roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<UserRoleDtoResponse> Create(UserRoleDtoRequest requests)
        {
            var appUser = await _userManager.FindByIdAsync(requests.UserId);
            if (appUser != null && requests.RoleIds!=null && requests.RoleIds.Count>0)
            {
                var role = await _userManager.AddToRolesAsync(appUser, requests.RoleIds);
                return new UserRoleDtoResponse(role.Succeeded ? null : role.Errors.Select(e => new Core.Dto.Error(e.Code, e.Description)), role.Succeeded);
            }
            return new UserRoleDtoResponse(false, "Please check request data!", (int)Constants.EnumStatusCode.BAD_INPUT);
        }

        public async Task<UserRoleDtoResponse> Delete(UserRoleDtoRequest requests)
        {
            var appUser = await _userManager.FindByIdAsync(requests.UserId);
            if (appUser != null && requests.RoleIds != null && requests.RoleIds.Count > 0)
            {
                var role = await _userManager.RemoveFromRolesAsync(appUser, requests.RoleIds);
                return new UserRoleDtoResponse(role.Succeeded ? null : role.Errors.Select(e => new Core.Dto.Error(e.Code, e.Description)), role.Succeeded);
            }
            return new UserRoleDtoResponse(false, "Please check request data!", (int)Constants.EnumStatusCode.BAD_INPUT);
        }
    }
}
