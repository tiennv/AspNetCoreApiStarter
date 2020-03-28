using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class UserRoleDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public UserRoleDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null, int statusCode = 200) : base(success, message, statusCode)
        {
            Errors = errors;
        }

        public UserRoleDtoResponse( bool success = false, string message = null, int statusCode=200) : base(success, message, statusCode)
        {
        }
    }
}
