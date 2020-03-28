﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto
{
    public sealed class UserRolePermission
    {
    }

    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class PermissionDto
    {
        public string Id { get; set; }
        public string ObjectId { get; set; }
        public string OperationId { get; set; }
    }

    public class RolePermissionDto
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string PermissionId { get; set; }
    }
}
