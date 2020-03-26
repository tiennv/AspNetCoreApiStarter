using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class ObjectsRepository : EfRepository<Objects>, IObjectsRepository
    {
        private readonly IMapper _mapper;
        public ObjectsRepository(IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public async Task<bool> Create(ObjectsRequest objects)
        {
            var entity = _mapper.Map<Objects>(objects);
            _appDbContext.Objects.Add(entity);
            return await _appDbContext.SaveChangesAsync() > 0 ? true : false;                        
        }
    }
}
