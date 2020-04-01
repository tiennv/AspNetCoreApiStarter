using AutoMapper;
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
    public class OperationsUserCase : IOperationsUserCase
    {
        private readonly IOperationsRepository _operationsRepository;
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;
        public OperationsUserCase(IOperationsRepository operationsRepository, IPermissionsRepository permissionsRepository, IMapper mapper)
        {
            _operationsRepository = operationsRepository;
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(List<OperationsDtoRequest> ids, IOutputPort<OperationsDtoResponse> outputPort)
        {
            var response = await _operationsRepository.Delete(ids);
            outputPort.Handle(response ? new OperationsDtoResponse(0, true, GlobalMessage.DELETE_SUCCESS_MES) : new OperationsDtoResponse(new[] { new Error(GlobalMessage.DELETE_FAIL_CODE, GlobalMessage.DELETE_FAIL_MES) }));
            return response;
        }

        public async Task<bool> Get(int id, IOutputPort<OperationsDtoResponse> outputPort)
        {
            var entity = await _operationsRepository.GetById(id);
            var objDto = _mapper.Map<OperationDto>(entity);
            outputPort.Handle(new OperationsDtoResponse(objDto, true, ""));
            return true;
        }

        public async Task<bool> GetByObject(int objectId, IOutputPort<OperationsDtoResponse> outputPort)
        {
            var objPermissions = await _permissionsRepository.ListAll();
            var objPerByObject = objPermissions.Where(x => x.ObjectId.Equals(objectId));
            var objOperations = _operationsRepository.ListAll().Result.Where(x=> objPerByObject.Any(o=>o.OperationId.Equals(x.Id)));

            var objDto = _mapper.Map<List<OperationDto>>(objOperations);
            outputPort.Handle(new OperationsDtoResponse(objDto, true, ""));
            return true;
        }

        public async Task<bool> Gets(IOutputPort<OperationsDtoResponse> outputPort)
        {
            var entities = await _operationsRepository.ListAll();
            var objDto = _mapper.Map<List<OperationDto>>(entities);
           
            outputPort.Handle(new OperationsDtoResponse(objDto, true, ""));

            return true;
        }

        public async Task<bool> Handle(OperationsDtoRequest message, IOutputPort<OperationsDtoResponse> outputPort)
        {
            var response = await _operationsRepository.Create(message);
            outputPort.Handle(response > 0  ? new OperationsDtoResponse(response,true, GlobalMessage.INSERT_SUCCESS_MES) : new OperationsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0 ? true : false;
        }
    }
}
