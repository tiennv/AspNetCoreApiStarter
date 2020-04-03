﻿using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class PermissionsDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public int Id { get; }
        public string Name { get; set; }
        public int ObjectId { get; }
        public int OperationId { get; }
        public List<PermissionDto> Permissions {get;}
        public PermissionsDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PermissionsDtoResponse(List<PermissionDto> permissionDtos, bool success = false, string message = null) : base(success, message)
        {
            Permissions = permissionDtos;
        }

        public PermissionsDtoResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;            
        }

        public PermissionsDtoResponse(int id=0,int objectId=0, int operationId=0, string name="", bool success = false, string message = null, int statusCode = 200) : base(success, message, statusCode)
        {
            Id = id;
            ObjectId = objectId;
            OperationId = operationId;
            Name = name;
        }
    }
}
