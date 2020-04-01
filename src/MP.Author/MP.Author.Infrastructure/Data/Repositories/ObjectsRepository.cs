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

        public async Task<bool> Create(ObjectsDtoRequest objects)
        {
            var entity = _mapper.Map<Objects>(objects);
            var entityInserted = _appDbContext.Objects.Add(entity);
            var inserted = await _appDbContext.SaveChangesAsync();
            // Neu co list childrent
            if(inserted > 0 && objects.Childrents!=null && objects.Childrents.Count > 0)
            {
                foreach(var item in objects.Childrents)
                {
                    if (item != null)
                    {
                        var child = _mapper.Map<Objects>(item);
                        child.ParentId = entityInserted.Entity.Id;
                        _appDbContext.Objects.Add(child);
                    }
                }

                await _appDbContext.SaveChangesAsync();
            }

            return inserted > 0 ? true : false;                        
        }

        public async Task<int> Create(List<ObjectsDtoRequest> requests)
        {
            var entities = _mapper.Map<List<Objects>>(requests);
            _appDbContext.Objects.AddRange(entities);
            var inserted = await _appDbContext.SaveChangesAsync();
            return inserted;
        }
    }
}
