﻿using AutoMapper;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Helpers;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class RoleUserCase : IRoleUserCase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;
        public RoleUserCase(IRoleRepository roleRepository, IPermissionsRepository permissionsRepository, 
            IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _permissionsRepository = permissionsRepository;
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<bool> GetByUserAsync(string userid, IOutputPort<RoleDtoResponse> outputPort)
        {
            var userRoleDtos = await _userRoleRepository.GetRoleByUserId(userid);
            var response = _mapper.Map<List<RoleDto>>(userRoleDtos);
            outputPort.Handle(new RoleDtoResponse(response, true, ""));

            return true;
        }

        public bool Gets(IOutputPort<RoleDtoResponse> outputPort)
        {
            var roles = _roleRepository.Gets();
            var response = _mapper.Map<List<RoleDto>>(roles);
            response.ForEach(x => x.Permissions = GetPermissionByRole(x.Id));
            outputPort.Handle(roles != null && roles.Count > 0 ? new RoleDtoResponse(response, true, "") : new RoleDtoResponse(new List<Error>(), false, "Has not roles!"));
            return response!=null && response.Count > 0;
        }

        public async Task<bool> Handle(RoleDtoRequest message, IOutputPort<RoleDtoResponse> outputPort)
        {
            var response = await _roleRepository.Create(message.Name);
            outputPort.Handle(response.Success  ? new RoleDtoResponse(response.Id, response.Name, true, GlobalMessage.INSERT_SUCCESS_MES) : new RoleDtoResponse(response.Errors, response.Success, response.Errors!=null ? response.Errors.FirstOrDefault().Description : ""));
            return response.Success;
        }

        private List<PermissionDto> GetPermissionByRole(string roleId)
        {
            var pers = _permissionsRepository.GetPermissionsByRoleId(roleId);
            return _mapper.Map<List<PermissionDto>>(pers);
        }
    }
}
