using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class OperationsDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public int Id { get; }
        public OperationsDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public OperationsDtoResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
