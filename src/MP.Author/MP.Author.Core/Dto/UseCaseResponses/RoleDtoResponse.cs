using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class RoleDtoResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public string Name { get; }
        public IEnumerable<Error> Errors { get; }
        public List<RoleDto> Roles { get; }

        public RoleDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RoleDtoResponse(List<RoleDto> roles, bool success = false, string message = null) : base(success, message)
        {
            Roles = roles;
        }

        public RoleDtoResponse(string id, string name, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
            Name = name;
        }
    }
}
