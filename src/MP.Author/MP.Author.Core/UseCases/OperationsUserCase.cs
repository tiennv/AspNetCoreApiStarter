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
    public class OperationsUserCase : IOperationsUserCase
    {
        private readonly IOperationsRepository _operationsRepository;

        public OperationsUserCase(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public async Task<bool> Handle(OperationsDtoRequest message, IOutputPort<OperationsDtoResponse> outputPort)
        {
            var response = await _operationsRepository.Create(message);
            outputPort.Handle(response > 0  ? new OperationsDtoResponse(response,true, GlobalMessage.INSERT_SUCCESS_MES) : new OperationsDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES) }));
            return response > 0 ? true : false;
        }
    }
}
