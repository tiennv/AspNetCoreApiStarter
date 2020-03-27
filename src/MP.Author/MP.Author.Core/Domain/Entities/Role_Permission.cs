using MP.Author.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Domain.Entities
{
    public class Role_Permission : BaseEntity
    {
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
        internal Role_Permission() { }
        internal Role_Permission(string roleId, int permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
