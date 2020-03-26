using MP.Author.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IObjectsRepository : IRepository<Objects>
    {
        Task<bool> Create(Objects objects);
    }
}
