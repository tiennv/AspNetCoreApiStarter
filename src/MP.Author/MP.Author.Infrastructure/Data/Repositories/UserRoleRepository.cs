using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.Gateways.Repositories;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        //private readonly IdentityUserRole
        private readonly IMapper _mapper;
        public UserRoleRepository(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<bool> Create(List<UserRoleDtoRequest> requests)
        {
            var appUser = await _userManager.FindByIdAsync(requests[0].UserId);
            if (appUser != null)
            {
                await _userManager.AddToRolesAsync(appUser, requests.Select(x => x.RoleId.ToUpper()));
                return true;
            }
            return false;
        }
    }
}
