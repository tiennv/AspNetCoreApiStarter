using AutoMapper;
using MP.Author.Core.Converts;
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
    public class ObjectsUseCase : IObjectsUseCase
    {
        private readonly IObjectsRepository _objectsRepository;
        private readonly IMapper _mapper;
        public ObjectsUseCase(IObjectsRepository objectsRepository, IMapper mapper)
        {
            _objectsRepository = objectsRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(List<ObjectsDtoRequest> request, IOutputPort<ObjectsDtoResponse> outputPort)
        {            
            var response = await _objectsRepository.Create(request);
            outputPort.Handle(response > 0 ? new ObjectsDtoResponse(response > 0, GlobalMessage.INSERT_SUCCESS_MES) : new ObjectsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0;
        }

        public async Task<bool> Delete(List<ObjectsDtoRequest> requests, IOutputPort<ObjectsDtoResponse> outputPort)
        {
            var response=  await _objectsRepository.Delete(requests);
            outputPort.Handle(response ? new ObjectsDtoResponse(response, GlobalMessage.DELETE_SUCCESS_MES) : new ObjectsDtoResponse(new[] { new Error(GlobalMessage.DELETE_FAIL_CODE, GlobalMessage.DELETE_FAIL_MES) }));
            return response;
        }

        public async Task<bool> Get(int id, IOutputPort<ObjectsDtoResponse> outputPort)
        {
            var entity = await _objectsRepository.GetById(id);
            var objDto = _mapper.Map<ObjectDto>(entity);
            outputPort.Handle(new ObjectsDtoResponse(objDto, true, ""));

            return true;
        }

        public async Task<bool> Gets(IOutputPort<ObjectsDtoResponse> outputPort)
        {
            var entities = await _objectsRepository.ListAll();
            var objDto = _mapper.Map<List<ObjectDto>>(entities);
            var objParents = objDto.Where(x => x.ParentId.Equals(0));
            var objResponse = ObjectsRecusiver.ReturnObjects(objDto, objParents.ToList());
            outputPort.Handle(new ObjectsDtoResponse(objResponse, true, ""));

            return true;
        }

        public async Task<bool> Handle(ObjectsDtoRequest message, IOutputPort<ObjectsDtoResponse> outputPort)
        {                    
            var response = await _objectsRepository.Create(message);
            outputPort.Handle(response ? new ObjectsDtoResponse(response, GlobalMessage.INSERT_SUCCESS_MES) : new ObjectsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES)}));
            return response;            
        }

        public async Task<bool> Update(ObjectsDtoRequest message, IOutputPort<ObjectsDtoResponse> outputPort)
        {
            var entity = _mapper.Map<Objects>(message);
            await _objectsRepository.Update(entity);
            outputPort.Handle(new ObjectsDtoResponse(true, GlobalMessage.UPDATE_SUCCESS_MES));
            return true;
        }
    }
}
