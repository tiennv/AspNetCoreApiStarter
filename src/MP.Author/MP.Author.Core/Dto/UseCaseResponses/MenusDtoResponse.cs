using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class MenusDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public List<MenusDto> Menus { get; set; } 
        public MenusDto Menu { get; set; }
        public MenusDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public MenusDtoResponse(List<MenusDto> menus, bool success = false, string message = null) : base(success, message)
        {
            Menus = menus;
        }

        public MenusDtoResponse(MenusDto menu, bool success = false, string message = null) : base(success, message)
        {
            Menu = menu;
        }


        public MenusDtoResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
