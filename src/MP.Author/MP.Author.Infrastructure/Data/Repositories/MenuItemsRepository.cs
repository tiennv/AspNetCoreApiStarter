using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class MenuItemsRepository : EfRepository<MenuItems>, IMenuItemsRepository
    {
        public MenuItemsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
