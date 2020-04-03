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
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class PermissionsUserCase : IPermissionsUserCase
    {
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;
        public PermissionsUserCase(IPermissionsRepository permissionsRepository, IMapper mapper)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<bool> GetAll(IOutputPort<PermissionsDtoResponse> outputPort)
        {
            var entities = await _permissionsRepository.ListAll();
            var objDto = _mapper.Map<List<PermissionDto>>(entities);
            outputPort.Handle(new PermissionsDtoResponse(objDto, true, ""));
            return true;
        }

        public async Task<bool> Handle(PermissionsDtoRequest message, IOutputPort<PermissionsDtoResponse> outputPort)
        {
            // Check exist            
            if (!_permissionsRepository.CheckExistObjectOperation(message))
            {
                var response = await _permissionsRepository.Create(message);
                outputPort.Handle(response > 0 ? new PermissionsDtoResponse(response, true, GlobalMessage.INSERT_SUCCESS_MES) : new PermissionsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
                return response > 0 ? true : false;
            }
            else
            {
                outputPort.Handle(new PermissionsDtoResponse(message.Id, message.ObjectId, message.OperationId, message.Name,false, GlobalMessage.EXIST_ITEM, 400));
                return false;
            }
        }
    }
}
