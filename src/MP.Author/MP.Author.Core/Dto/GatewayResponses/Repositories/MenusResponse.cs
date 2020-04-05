using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.GatewayResponses.Repositories
{
    public class MenusResponse : BaseGatewayResponse
    {
        public MenusDto Menu { get; }
        public MenusResponse(MenusDto menu, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Menu = menu;
        }
    }
}
