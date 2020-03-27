using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class UserRoleDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public UserRoleDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UserRoleDtoResponse( bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
