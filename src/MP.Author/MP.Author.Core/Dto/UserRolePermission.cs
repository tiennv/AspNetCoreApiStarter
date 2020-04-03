using MP.Author.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Name { get; set; }
    }

    public class RolePermissionDto
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string PermissionId { get; set; }
    }

    public class OperationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Import { get; set; }
        public bool Export { get; set; }

        
    }

    public class ObjectDto 
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string ParentName { get; private set; }
        public string Method { get; private set; }
        public bool IsPage { get; private set; }
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public bool IsApp { get; private set; }
        public bool IsShow { get; private set; }
        public int ParentId { get; set; }
        public string Route { get; private set; }
        public string EnumAction { get; private set; }
        public string Icon { get; private set; }
        public OperationDto Operation { get; set; }
        public List<OperationDto> Operations { get; set; }
        public List<ObjectDto> Childrents { get; set; }
    }    
}

