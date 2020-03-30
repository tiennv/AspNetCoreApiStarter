using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class LoginDtoResponse : UseCaseResponseMessage
    {
        public List<RoleDto> Roles { get; }
        public List<ObjectDto> Objects { get; }
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public IEnumerable<Error> Errors { get; }

        public LoginDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LoginDtoResponse(List<ObjectDto> objects, List<RoleDto> roles, AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Roles = roles;
            Objects = objects;
        }
    }
}
