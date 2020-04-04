using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class UserDtoResponse : UseCaseResponseMessage
    {
        public List<UserDto> Users { get; }

        public UserDtoResponse(bool success = false, string message = null, int statusCode = 200) : base(success, message, statusCode)
        {
        }

        public UserDtoResponse(List<UserDto> users, bool success = false, string message = null, int statusCode = 200) : base(success, message, statusCode)
        {
            Users = users ;
        }
    }
}
