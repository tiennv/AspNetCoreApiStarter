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
    public class RolePermissionRepository : EfRepository<Role_Permission>, IRolePermissionRepository
    {
        private readonly IMapper _mapper;

        public RolePermissionRepository(IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public async Task<int> Create(RolePermissionDtoRequest request)
        {
            var entity = _mapper.Map<Role_Permission>(request);
            var entityInserted = _appDbContext.Role_Permission.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entityInserted.Entity.Id;
        }
    }
}
