using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class ObjectsRepository : EfRepository<Objects>, IObjectsRepository
    {
        public ObjectsRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<bool> Create(Objects objects)
        {
            _appDbContext.Objects.Add(objects);
            await _appDbContext.SaveChangesAsync();

            return true; 
        }
    }
}
