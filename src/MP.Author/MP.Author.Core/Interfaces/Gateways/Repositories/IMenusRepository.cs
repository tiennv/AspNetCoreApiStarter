using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IMenusRepository : IRepository<Menus>
    {
        //Task<bool> GetAll(IOutputPort<MenusDtoResponse> outputPort);
    }
}
