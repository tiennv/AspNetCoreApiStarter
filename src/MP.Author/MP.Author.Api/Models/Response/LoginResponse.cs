using MP.Author.Core.Dto;
using System;
using System.Collections.Generic;

namespace MP.Author.Api.Models.Response
{
    public class LoginResponse
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public List<RoleDto> Roles { get; set; }

        public List<ObjectDto> Objects { get; set; }
        public string refresh_token { get; }
        public string token { get; }
        public string ttl { get; }

        public LoginResponse(AccessToken accessToken, List<RoleDto> roles, List<ObjectDto> objects, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Roles = roles;
            Objects = objects;
            refresh_token = RefreshToken;
            token = AccessToken.Token;
            ttl = DateTime.Now.AddSeconds(AccessToken.ExpiresIn).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
