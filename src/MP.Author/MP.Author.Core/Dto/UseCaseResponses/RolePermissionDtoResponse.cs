using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class RolePermissionDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public int Id { get; }
        public RolePermissionDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RolePermissionDtoResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
