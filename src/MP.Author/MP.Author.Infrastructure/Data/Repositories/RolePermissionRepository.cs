using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> Create(List<RolePermissionDtoRequest> requests)
        {
            var entities = _mapper.Map<List<Role_Permission>>(requests);
            _appDbContext.Role_Permission.AddRange(entities);
            var inserted = await _appDbContext.SaveChangesAsync();
            return inserted;
        } 

        public List<Role_Permission> GetPermissionsByRoleId(string roleId)
        {
            return _appDbContext.Role_Permission.Where(x => x.RoleId.Equals(roleId)).ToList();
        }
    }
}
