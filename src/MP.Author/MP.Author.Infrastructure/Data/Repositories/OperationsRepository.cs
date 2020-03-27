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
    public sealed class OperationsRepository : EfRepository<Operations>, IOperationsRepository
    {
        private readonly IMapper _mapper;
        public OperationsRepository(IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public async Task<int> Create(OperationsDtoRequest request)
        {
            var entity = _mapper.Map<Operations>(request);
            var entityInserted = _appDbContext.Operations.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entityInserted.Entity.Id;
            
        }
    }
}
