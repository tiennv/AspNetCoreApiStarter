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
    public class PermissionsRepository : EfRepository<Permissions>, IPermissionsRepository
    {
        private readonly IMapper _mapper;
        public PermissionsRepository(IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public async Task<int> Create(PermissionsDtoRequest request)
        {
            var entity = _mapper.Map<Permissions>(request);
            var entityInserted = _appDbContext.Permissions.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entityInserted.Entity.Id;
        }
    }
}
