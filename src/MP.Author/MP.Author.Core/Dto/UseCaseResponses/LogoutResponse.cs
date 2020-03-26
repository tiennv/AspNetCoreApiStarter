using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class LogoutResponse : UseCaseResponseMessage
    {    
        public IEnumerable<Error> Errors { get; }
        

        public LogoutResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LogoutResponse(bool success = false, string message = null) : base(success, message)
        {
        
        }
    }
}
