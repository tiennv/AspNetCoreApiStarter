using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class ObjectsResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public ObjectsResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ObjectsResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
