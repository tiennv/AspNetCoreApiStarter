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
    public class ObjectsUserCase : IObjectsUserCase
    {
        private readonly IObjectsRepository _objectsRepository;        

        public ObjectsUserCase(IObjectsRepository objectsRepository)
        {
            _objectsRepository = objectsRepository;
        }

        public async Task<bool> Handle(ObjectsRequest message, IOutputPort<ObjectsDtoResponse> outputPort)
        {                    
            
            var response = await _objectsRepository.Create(message);
            outputPort.Handle(response ? new ObjectsDtoResponse(response, GlobalMessage.INSERT_SUCCESS_MES) : new ObjectsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES)}));
            return response;

        }
    }
}
