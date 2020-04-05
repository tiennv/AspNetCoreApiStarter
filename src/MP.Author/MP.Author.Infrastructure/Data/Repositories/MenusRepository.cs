using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class MenusRepository : EfRepository<Menus>, IMenusRepository
    {
        private readonly IMapper _mapper;
        public MenusRepository(IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _mapper = mapper;
        }        
    }
}
