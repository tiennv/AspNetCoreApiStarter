using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class MenuItemsRepository : EfRepository<MenuItems>, IMenuItemsRepository
    {
        public MenuItemsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public  List<MenuItemDto> GetByMenuId(int menuId)
        {
            var entites = (from mi in _appDbContext.MenuItems
                                         join o in _appDbContext.Objects
                                         on mi.ObjectId equals o.Id
                                         where mi.MenuId.Equals(menuId)
                                         select new MenuItemDto
                                         {
                                             //Id = mi.Id,
                                             ObjectName = o.Name,
                                             ObjectId = mi.ObjectId,
                                             MenuId = mi.MenuId
                                         }).Distinct().ToList();

            return entites;
        }
    }
}
