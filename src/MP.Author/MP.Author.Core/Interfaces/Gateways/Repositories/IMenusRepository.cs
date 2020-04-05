﻿using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Dto.UseCaseRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IMenusRepository : IRepository<Menus>
    {
        //Task<MenusResponse> Create(MenusDtoRequest request);
    }
}
