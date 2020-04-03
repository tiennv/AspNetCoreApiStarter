using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public bool CheckExistObjectOperation(PermissionsDtoRequest request)
        {
            var entity = _appDbContext.Permissions.FirstOrDefault(x => x.ObjectId == request.ObjectId && x.OperationId == request.OperationId);

            return entity == null ? false : true;
        }

        public async Task<int> Create(PermissionsDtoRequest request)
        {
            var entity = _mapper.Map<Permissions>(request);
            var entityInserted = _appDbContext.Permissions.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entityInserted.Entity.Id;
        }

        public List<Permissions> GetPermissionsByRoleId(string roleId)
        {
            var entites = (from p in _appDbContext.Permissions
                          join r in _appDbContext.Role_Permission
                          on p.Id equals r.PermissionId
                          where r.RoleId.Equals(roleId)
                          select new Permissions
                          {
                              Id = p.Id,
                              Name = p.Name,
                              ObjectId = p.ObjectId,
                              OperationId = p.OperationId                              
                          }).ToList();

            return entites;
                    
        }
    }
}
