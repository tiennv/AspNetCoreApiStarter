using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Request
{
    public class UserRoleRequest
    {
    }

    public class AddUserRoleRequest
    {
        public string UserId { get; set; }
        public List<string> RoleIds { get; set; }
    }
}
