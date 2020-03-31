using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int OperationId { get; set; }

        public virtual Objects Object { get; set; }
        public virtual Operations Operation { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
