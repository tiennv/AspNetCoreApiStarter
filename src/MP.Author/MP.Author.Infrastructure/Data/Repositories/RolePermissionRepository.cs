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

        public Role_Permission GetByRolePermission(string roleId, int permissionId)
        {
            return _appDbContext.Role_Permission.FirstOrDefault(x => x.PermissionId.Equals(permissionId) && x.RoleId.Equals(roleId));
        }

        public async Task<bool> DeleteByRolePermissionAsync(string roleId, int permissionId)
        {
            var entity = _appDbContext.Role_Permission.FirstOrDefault(x => x.PermissionId.Equals(permissionId) && x.RoleId.Equals(roleId));
            if (entity != null)
            {
                _appDbContext.Remove(entity);
                var deleted = await _appDbContext.SaveChangesAsync();
                return deleted > 0;
            }
            return true;
        }

        public List<Role_Permission> GetPermissionsByRoleId(string roleId)
        {
            return _appDbContext.Role_Permission.Where(x => x.RoleId.Equals(roleId)).ToList();
        }

        public async Task<bool> DeleteByRolePermissionAsync(string roleId)
        {
            var obj = GetPermissionsByRoleId(roleId);
            if(obj!=null && obj.Count > 0)
            {
                _appDbContext.RemoveRange(obj);
                await _appDbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
