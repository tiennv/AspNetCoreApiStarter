using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Request
{
    public class RolePermissionRequest
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
        public List<RoleObjectOperationRequest> Objects { get; set; }
    }

    public class RoleObjectOperationRequest
    {
        public int ObjectId { get; set; }
        public int PermissionId { get; set; }
        public int OperationId { get; set; }
        public OperationsRequest Operation { get; set; }
    }
}
