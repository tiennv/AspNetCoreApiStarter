using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.Gateways.Repositories
{
    public interface IMenuItemsRepository : IRepository<MenuItems>
    {
        List<MenuItemDto> GetByMenuId(int menuId);
    }
}
