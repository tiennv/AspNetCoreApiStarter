using MP.Author.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Domain.Entities
{
    public class Permissions : BaseEntity
    {
        public string Name { get; set; }
        public int ObjectId { get; set; }
        public int OperationId { get; set; }
        public virtual Objects Object { get; set; }
        public virtual Operations Operation { get; set; }
        public virtual ICollection<Role_Permission> RolePermission { get; set; }
        internal Permissions() {
            RolePermission = new HashSet<Role_Permission>();
        }
        internal Permissions(int objectId, int operationId)
        {
            OperationId = operationId;
            ObjectId = objectId;
        }

        internal Permissions(int id, int objectId, int operationId)
        {
            Id = id;
            OperationId = operationId;
            ObjectId = objectId;
        }
    }
}
