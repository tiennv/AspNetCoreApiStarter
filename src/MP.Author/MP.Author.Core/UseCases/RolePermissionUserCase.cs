﻿using AutoMapper;
using MP.Author.Core.Domain.Entities;
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
    public class RolePermissionUserCase : IRolePermissionUserCase
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;
        public RolePermissionUserCase(IRolePermissionRepository rolePermissionRepository, IPermissionsRepository permissionsRepository, IMapper mapper)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RolePermissionDtoRequest message, IOutputPort<RolePermissionDtoResponse> outputPort)
        {
            var response = await _rolePermissionRepository.Create(message);
            outputPort.Handle(response > 0 ? new RolePermissionDtoResponse(response, true, GlobalMessage.INSERT_SUCCESS_MES) : new RolePermissionDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0 ? true : false;
        }

        public async Task<bool> Create(List<RolePermissionDtoRequest> requests, IOutputPort<RolePermissionDtoResponse> outputPort)
        {
            var listCurrent = _rolePermissionRepository.GetPermissionsByRoleId(requests[0].RoleId);
            await PopulatorRolePermissionsAsync(listCurrent, _mapper.Map<List<Role_Permission>>(requests));
            //var response = await _rolePermissionRepository.Create(requests);
            outputPort.Handle(new RolePermissionDtoResponse(0, true, GlobalMessage.INSERT_SUCCESS_MES));
            return true;
        }       

        private async Task PopulatorRolePermissionsAsync(List<Role_Permission> currents, List<Role_Permission> news)
        {
            var listStay = new List<Role_Permission>();
            var listRemove = new List<Role_Permission>();
            var listAdd = new List<Role_Permission>();

            if (currents.Count > news.Count)
            {
                listStay = currents.Where(s => news.Any(n => n.PermissionId.Equals(s.PermissionId))).ToList();
                //listRemove = currents.Where(s => news.All(n => !n.PermissionId.Equals(s.PermissionId))).ToList();

            }
            else
            {
                // xem trong list news co item nao van giu, khong remove di
                listStay = news.Where(s => currents.Any(n => n.PermissionId.Equals(s.PermissionId))).ToList();

                //if (listStay != null && listStay.Count > 0)
                //{
                //    // lay ra list add moi theo list news
                //    listAdd = news.Where(n => listStay.All(s => !s.PermissionId.Equals(n.PermissionId))).ToList();

                //    // list remove 
                //    listRemove = currents.Where(s => news.All(n => !n.PermissionId.Equals(s.PermissionId))).ToList();
                //}
                //else
                //{
                //    listAdd = news;
                //    listRemove = currents;
                //}
            }

            if (listStay != null && listStay.Count > 0)
            {
                // lay ra list add moi theo list news
                listAdd = news.Where(n => listStay.All(s => !s.PermissionId.Equals(n.PermissionId))).ToList();

                // list remove 
                listRemove = currents.Where(s => news.All(n => !n.PermissionId.Equals(s.PermissionId))).ToList();
            }
            else
            {
                listAdd = news;
                listRemove = currents;
            }

            foreach (var item in listRemove)
            {
                await _rolePermissionRepository.Delete(item);
            }

            foreach (var item in listAdd)
            {
                await _rolePermissionRepository.Add(item);
            }
        }
    }
}
