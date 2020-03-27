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

        public RoleDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RoleDtoResponse(string id, string name, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
