using MP.Author.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Response
{
    public class UserRolePermissionResponse
    {
        public class PermissionResponse
        {
            public int PermissionId { get; set; }
            public Objects Objects { get; set; }
            public List<Operations> Operations { get; set; }
        }

        public class RolePermissionResponse
        {
            public string RoleId { get; set; }
            public string Name { get; set; }
            public List<PermissionResponse> PermissionResponses { get; set; }
        }


        public class UserRole
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public List<RolePermissionResponse> RolePermissionResponses { get; set; }
            public List<PermissionResponse> PermissionResponses { get; set; }
        }
    }
}
