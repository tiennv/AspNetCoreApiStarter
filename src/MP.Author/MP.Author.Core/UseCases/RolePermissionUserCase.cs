using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Helpers;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class RolePermissionUserCase : IRolePermissionUserCase
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        public RolePermissionUserCase(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<bool> Handle(RolePermissionDtoRequest message, IOutputPort<RolePermissionDtoResponse> outputPort)
        {
            var response = await _rolePermissionRepository.Create(message);
            outputPort.Handle(response > 0 ? new RolePermissionDtoResponse(response, true, GlobalMessage.INSERT_SUCCESS_MES) : new RolePermissionDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0 ? true : false;
        }

        public async Task<bool> Create(List<RolePermissionDtoRequest> requests, IOutputPort<RolePermissionDtoResponse> outputPort)
        {
            var response = await _rolePermissionRepository.Create(requests);
            outputPort.Handle(response > 0 ? new RolePermissionDtoResponse(response, true, GlobalMessage.INSERT_SUCCESS_MES) : new RolePermissionDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0;
        }
    }
}
