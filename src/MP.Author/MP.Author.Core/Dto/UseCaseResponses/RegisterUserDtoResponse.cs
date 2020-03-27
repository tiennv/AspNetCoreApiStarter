using MP.Author.Core.Interfaces;
using System.Collections.Generic;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class RegisterUserDtoResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterUserDtoResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterUserDtoResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
