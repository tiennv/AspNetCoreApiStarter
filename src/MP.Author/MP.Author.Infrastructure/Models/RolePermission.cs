using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permissions Permission { get; set; }
    }
}
