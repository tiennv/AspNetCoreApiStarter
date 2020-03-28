using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleRepository(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleResponse> Create(string name)
        {
            var identityResult = await _roleManager.CreateAsync(new IdentityRole { Name = name });            
            return new RoleResponse("", name, identityResult.Succeeded, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<RoleResponse> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                return new RoleResponse(role.Id, role.Name, result.Succeeded, result.Succeeded ? null : result.Errors.Select(e => new Error(e.Code, e.Description)));
            }
            var errors = new List<Error>();
            errors.Add(new Error("not_found", "Not found item"));
            return new RoleResponse(id, "", false, errors);
        }

        public async Task<RoleResponse> Update(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                role.Name = name;
                var result = await _roleManager.UpdateAsync(role);
                return new RoleResponse(role.Id, role.Name, result.Succeeded, result.Succeeded ? null : result.Errors.Select(e => new Error(e.Code, e.Description)));
            }

            var errors = new List<Error>();
            errors.Add(new Error("action_fail", "Update fail"));
            return new RoleResponse(id, name, false, errors);
        }

        public async Task<RoleResponse> GetRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                return new RoleResponse(role.Id, role.Name, true, null);
            }
            return new RoleResponse("", "", false, null);
        }

        
    }
}
