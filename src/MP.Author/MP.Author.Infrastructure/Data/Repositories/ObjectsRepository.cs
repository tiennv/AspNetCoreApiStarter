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
            if(inserted > 0 && objects.Children!=null && objects.Children.Count > 0)
            {
                foreach(var item in objects.Children)
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
            var inserted = 0;
            foreach (var item in requests)
            {
                var entityInserted = _appDbContext.Objects.Add(_mapper.Map<Objects>(item));
                inserted = await _appDbContext.SaveChangesAsync();
                if (inserted > 0 && item.Children != null && item.Children.Count > 0)
                {
                    item.Children.ForEach(x => x.ParentId = entityInserted.Entity.Id);
                    _appDbContext.Objects.AddRange(_mapper.Map<List<Objects>>(item.Children));
                    await _appDbContext.SaveChangesAsync();
                }
            }
            
            return inserted;
        }

        public async Task<bool> Delete(List<ObjectsDtoRequest> request)
        {
            var entities = _mapper.Map<List<Objects>>(request);
            _appDbContext.Objects.RemoveRange(entities);
            var inserted = await _appDbContext.SaveChangesAsync();
            return inserted > 0;
        }

    }
}
