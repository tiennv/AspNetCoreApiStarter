using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.UseCaseRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IOperationsRepository : IRepository<Operations>
    {
        Task<int> Create(OperationsDtoRequest request);
        Task<bool> Delete(List<OperationsDtoRequest> requests);
    }
}
